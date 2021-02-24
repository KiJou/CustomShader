using Naninovel;
using UniRx.Async;
using UnityEngine;

public class TimeOfDay : MonoBehaviour
{
    public static float CurrentHour { get; private set; }

    [SerializeField] private new Light light = default;
    [SerializeField] private Gradient lightGradient = default;
    [SerializeField] private AnimationCurve emissionGradient = default;

    private static readonly int emissionId = Shader.PropertyToID("_Emission");
    private static readonly Tweener<FloatTween> tweener = new Tweener<FloatTween>();
    private static TimeOfDay instance;

    public static void SetHour (float hour)
    {
        CurrentHour = hour % 24;

        var gradient = CurrentHour / 24;

        var lightColor = instance.lightGradient.Evaluate(gradient);
        instance.light.color = lightColor;

        var emission = instance.emissionGradient.Evaluate(gradient);
        Shader.SetGlobalFloat(emissionId, emission);
    }

    public static async UniTask SetHourAsync (float hour, float duration,
        CancellationToken cancellationToken = default)
    {
        if (tweener.Running) tweener.CompleteInstantly();
        var tween = new FloatTween(CurrentHour, hour, duration, SetHour, target: instance);
        await tweener.RunAsync(tween, cancellationToken);
    }

    private void Awake ()
    {
        instance = this;
        SetHour(0);
    }
}
