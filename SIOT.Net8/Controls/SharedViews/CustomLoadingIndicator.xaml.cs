namespace SIOT.Controls;

public partial class CustomLoadingIndicator : Border
{

    private bool _playing = false;
    private Animation _animation;

    public CustomLoadingIndicator()
    {
        InitializeComponent();
    }

    public void Start()
    {
        _animation = new Animation(
            callback: d => actIndicator.RotationY = d,
            start: 0,
            end: 360,
            easing: Easing.Linear);

        _playing = true;
        _animation.Commit(actIndicator, "Loop", length: 1000, repeat: () => _playing);
    }

    public void Stop()
    {
        _playing = false;
        _animation = null;
    }
}
