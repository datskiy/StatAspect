using StatAspect.Domain._Core.UserRegistry.Aggregates;
using StatAspect.Domain._Core.UserRegistry.Managers;
using StatAspect.Domain._Core.UserRegistry.Repositories;
using StatAspect.SharedKernel.Results;

namespace StatAspect.Infrastructure._Core.UserRegistry.Managers.Implementations;

public sealed class UserCredentialsManager : IUserCredentialsManager
{
    private readonly IUserCredentialsQueryRepository _userCredentialsQueryRepository;

    public UserCredentialsManager(IUserCredentialsQueryRepository userCredentialsQueryRepository)
    {
        _userCredentialsQueryRepository = userCredentialsQueryRepository;
    }

    public async Task<OneOf<UserCredentials, NotFound, Mismatched>> VerifyAsync(string username, string password, CancellationToken cancellationToken = default)
    {
        Guard.Argument(() => username).NotNull();
        Guard.Argument(() => password).NotNull();

        var userCredentials = await _userCredentialsQueryRepository.GetSingleAsync(username, cancellationToken);
        if (userCredentials is null)
            return new NotFound();

        // var doesPasswordMatch = _passwordManager.Matches(password, userCredentials.PasswordHash, userCredentials.PasswordSalt); // TODO: implement
        // if(!doesPasswordMatch)
        //  return new Mismatched();

        return userCredentials;
    }
}