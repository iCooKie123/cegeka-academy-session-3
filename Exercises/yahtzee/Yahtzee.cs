public class Yahtzee {

    public static void CheckDice(params int[] dice)
    {
        if (dice.Length != 5)
            throw new ArgumentException("dice must have 5 elements", "dice");
        if (dice.Any(d => d < 1 || d > 6))
            throw new ArgumentException("dice must have values between 1 and 6", "dice");
    }

    public static int Chance(params int[] dice)
    {
        CheckDice(dice);
        return dice.Sum();
    }

    public static int yahtzee(params int[] dice)
    {
        CheckDice(dice);
        if (dice.Distinct().Count() == 1)
            return 50;
        return 0;
    }

    public static int AllKindOfScores(int[] dice, int kind)
    {
        CheckDice(dice);
        int total=0;
        total+= dice.Where(d => d == kind).Sum();
        return total;
    }

    public static int Ones(params int[] dice) {
        return AllKindOfScores(dice, 1);
    }

    public static int Twos(params int[] dice) {
        return AllKindOfScores(dice, 2);
    }

    public static int Threes(params int[] dice) {
        return AllKindOfScores(dice, 3);
    }

    protected int[] dice;
    public Yahtzee(params int[] diceGiven)
    {
        CheckDice(diceGiven);
        dice = diceGiven;
        
    }

    public int Fours()
    {
        return AllKindOfScores(dice, 4);
    }

    public int Fives()
    {
        return AllKindOfScores(dice, 5);
    }

    public int sixes()
    {
        return AllKindOfScores(dice, 6);
    }

    public static int ScorePair(params int[] dice)
    {
        CheckDice(dice);
        var score = dice.GroupBy(d => d).Where(d => d.Count() == 2).Select(d => d.Key*2);
        return score.Max();
    }

    public static int TwoPair(params int[] dice)
    {
        CheckDice(dice);

        var score = dice.GroupBy(d => d).Where(d => d.Count() ==2).Select(d => d.Key * 2);
        if(score.Count()==2)
            return score.Sum();
        return 0;
    }

    public static int FourOfAKind(params int[] dice)
    {
        CheckDice(dice);

        return dice.GroupBy(d => d).Where(d => d.Count() ==4).Select(d => d.Key * 4).Sum();
    }

    public static int ThreeOfAKind(params int[] dice)
    {
        CheckDice(dice);

        return dice.GroupBy(d => d).Where(d => d.Count() == 3).Select(d => d.Key * 3).Sum();
    }

    


    public static int SmallStraight(params int[] dice)
    {
        CheckDice(dice);
        int[] correctSmallStraightInts = { 1, 2, 3, 4, 5 };

        dice= dice.OrderBy(d => d).ToArray();
        if (dice.SequenceEqual(correctSmallStraightInts))
            return 15;
        return 0;
        

    }

    public static int LargeStraight(params int[] dice)
    {
        CheckDice(dice);

        int[] correctLargeStraightInts = { 2,3,4,5,6 };
        dice = dice.OrderBy(d => d).ToArray();
        if (dice.SequenceEqual(correctLargeStraightInts))
            return 20;
        return 0;
    }

    public static int FullHouse(params int[] dice)
    {
        CheckDice(dice);

        bool hasTwo = dice.GroupBy(d => d).Where(d => d.Count() == 2).Count() == 1;
        bool hasThree = dice.GroupBy(d => d).Where(d => d.Count() == 3).Count() == 1;
        if(hasThree && hasTwo)
            return dice.Sum();
        return 0;

        //trebuie mentionat aici ca hasTwo si hasThree au fost folosite pentru a usura citirea codului, ar fi putut fi doar un if cu ambele conditii
    }
}
