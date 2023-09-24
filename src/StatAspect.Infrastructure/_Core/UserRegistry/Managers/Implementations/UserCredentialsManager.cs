using StatAspect.Domain._Core.UserRegistry.Managers;
using StatAspect.Domain._Core.UserRegistry.Repositories;
using StatAspect.Domain._Core.UserRegistry.ValueObjects;
using StatAspect.Domain._Core.UserRegistry.ValueObjects.Identifiers;
using StatAspect.SharedKernel.Results;

namespace StatAspect.Infrastructure._Core.UserRegistry.Managers.Implementations;

public sealed class UserCredentialsManager : IUserCredentialsManager
{
    private readonly IUserCredentialsQueryRepository _userCredentialsQueryRepository;

    public UserCredentialsManager(IUserCredentialsQueryRepository userCredentialsQueryRepository)
    {
        _userCredentialsQueryRepository = userCredentialsQueryRepository;
    }

    public async Task<OneOf<UserId, NotFound, Mismatched>> VerifyAsync(Username username, Password password, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(username);
        ArgumentNullException.ThrowIfNull(password);

        var userCredentials = await _userCredentialsQueryRepository.GetSingleAsync(username, cancellationToken);
        if (userCredentials is null)
            return new NotFound();

        // var doesPasswordMatch = _passwordManager.Matches(password, userCredentials.PasswordHash, userCredentials.PasswordSalt); // TODO: implement
        // if(!doesPasswordMatch)
        //  return new Mismatched();

        return userCredentials.UserId;
    }
}