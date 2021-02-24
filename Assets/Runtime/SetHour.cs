using Naninovel;
using UniRx.Async;

[CommandAlias("hour")]
public class SetHour : Command
{
    [ParameterAlias(NamelessParameterAlias), RequiredParameter]
    public DecimalParameter Hour;
    public DecimalParameter Duration = 1;

    public override async UniTask ExecuteAsync (CancellationToken cancellationToken = default)
    {
        await TimeOfDay.SetHourAsync(Hour, Duration, cancellationToken);
    }
}
