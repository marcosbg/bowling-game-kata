namespace BowlingGame.Domain;

public class Game
{
    Frame[] frames = new Frame[10];
    private int currentFrame = 0;

    public void Roll(int pins)
    {
        if (frames[currentFrame] == null)
        {
            frames[currentFrame] = new Frame();
        }

        frames[currentFrame].Roll(pins);

        if (frames[currentFrame].Status >= FrameStatus.COMPLETED)
            currentFrame += 1;
    }

    public int Score()
    {
        var score = 0;
        for (int i = 0; i < 10; i++)
        {
            var frame = frames[i];
            if (frame == null)
                break;

            score += frame.FirstRoll;

            if (i > 0 &&
                (frames[i - 1].Status == FrameStatus.SPARE ||
                 frames[i - 1].Status == FrameStatus.STRIKE))
            {
                score += frame.FirstRoll;
            }

            score += frame.SecondRoll;

            if (i > 0 &&
                frames[i - 1].Status == FrameStatus.STRIKE)
            {
                score += frame.SecondRoll;
            }
        }
        return score;
    }
}
