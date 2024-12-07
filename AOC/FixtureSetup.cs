using Pillsgood.AdventOfCode;
using Pillsgood.AdventOfCode.Login;

namespace AOC;

[SetUpFixture]
public class FixtureSetup
{
    private IAsyncDisposable? _disposable;

    [OneTimeSetUp]
    public async ValueTask Setup()
    {
        _disposable = await Registrations.StartAsync(config => config.WithLogin());
    }

    [OneTimeTearDown]
    public async ValueTask DisposeAsync()
    {
        if (_disposable is not null)
        {
            await _disposable.DisposeAsync();
        }
    }
}