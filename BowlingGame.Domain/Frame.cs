namespace BowlingGame.Domain;

public class Frame
{
    public FrameStatus Status { get; private set; }
    public int FirstRoll { get; private set; }
    public int SecondRoll { get; private set; }

    public Frame()
    {
        Status = FrameStatus.FIRST_ROLL;
    }

    public void Roll(int pins)
    {
        if (Status >= FrameStatus.COMPLETED)
            throw new InvalidOperationException();

        if (Status == FrameStatus.FIRST_ROLL)
        {
            FirstRoll = pins;

            if (FirstRoll == 10)
            {
                Status = FrameStatus.STRIKE;
            }
            else
                Status = FrameStatus.SECOND_ROLL;

        }
        else if (Status == FrameStatus.SECOND_ROLL)
        {
            SecondRoll = pins;

            if (FirstRoll + SecondRoll == 10)
            {
                Status = FrameStatus.SPARE;
            }
            else
                Status = FrameStatus.COMPLETED;
        }
    }
}

public enum FrameStatus
{
    FIRST_ROLL,
    SECOND_ROLL,
    COMPLETED,
    SPARE,
    STRIKE
}
