using StatAspect.Domain._Core.UserRegistry.Managers;
using StatAspect.Domain._Core.UserRegistry.Repositories;
using StatAspect.Domain._Core.UserRegistry.ValueObjects;
using StatAspect.Domain._Core.UserRegistry.ValueObjects.Identifiers;
using StatAspect.SharedKernel.OneOf.Results;

namespace StatAspect.Infrastructure._Core.UserRegistry.Managers.Implementations;

public sealed class UserCredentialsManager : IUserCredentialsManager
{
    private readonly IUserCredentialsQueryRepository _userCredentialsQueryRepository;

    public UserCredentialsManager(IUserCredentialsQueryRepository userCredentialsQueryRepository)
    {
        _userCredentialsQueryRepository = userCredentialsQueryRepository;
    }

    public async Task<OneOf<UserId, NotFound, Mismatched>> VerifyAsync(Username username, Password password, CancellationToken cancellationToken = default) // TODO: implement
    {
        ArgumentNullException.ThrowIfNull(username);
        ArgumentNullException.ThrowIfNull(password);

        var userCredentials = await _userCredentialsQueryRepository.GetSingleAsync(username, cancellationToken);
        if (userCredentials is null)
            return new NotFound();

        // var passwordMatches = _passwordManager.Matches(password, userCredentials.PasswordHash, userCredentials.PasswordSalt);
        // if(!passwordMatches)
        //  return new Mismatched();

        return userCredentials.UserId;
    }
}