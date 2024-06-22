namespace WindowsPet
{
    public enum AnimationState
    {
        Idle,
        Moving
    }

    public enum MovementState
    {
        Nowhere,
        TowardsMouse,
        TowardsFocusedWindow,
        TowardsRandomLocation
    }

    public enum Direction
    {
        Left,
        Right
    }

    public class Pet(Animation idleAnimation, Animation walkAnimation, Bitmap petIcon, int speedInPixelsPerSec, int minBehaviorStateTime, int maxBehaviorStateTime)
    {
        public Bitmap PetIcon { get; init; } = petIcon;
        public Size Size { get; init; } = idleAnimation.Dimentions;
        public Direction Direction { get; set; } = Direction.Left;
        public Animation IdleAnimation { get; init; } = idleAnimation;
        public Animation WalkAnimation { get; init; } = walkAnimation;
        public AnimationState AnimationState { get; set; } = AnimationState.Idle;
        public MovementState MovementState { get; set; } = MovementState.Nowhere;
        public int SpeedInPixelsPerSec { get; init; } = speedInPixelsPerSec;
        public int MinBehaviorStateTime { get; init; } = minBehaviorStateTime;
        public int MaxBehaviorStateTime { get; init; } = maxBehaviorStateTime;
    }
}
