using System;

private void printGuessStatistice (char candidate, int count) {
    string number;
    string verb;
    string pluraModifier;
    if (count == 0) {
        number = "no";
        verb = "are";
        pluralModifier = "s";
    } else if (count == 1) {
        number = "1";
        verb = "is";
        pluraModifier = "";
    } else {
        number = count.ToString ();
        verb = "are";
        pluraModifier = "s";
    }

    string guessMessage = string.Format ("There {0} {1} {2} {3}{4}", verb, number, candidate, pluraModifier);

    Console.WriteLine (guessMessage);

    // 1. 函式些許過長
    // 2. 區域變數幾乎在整個函式裡都被使用
}

public class GuessStatisticsMessage {
    private string number;
    private string verb;
    private string pluralModifier;

    public string make (char candidate, int count) {
        createPluralDependentMessageParts (count);
        return string.Format ("There {0} {1} {2} {3}{4}", verb, number, candidate, pluraModifier);
    }

    private void createPluralDependentMessageParts (int count) {
        if (count == 0) {
            thereAreNoLetters ();
        } else if (count == 1) {
            thereIsOneLetter ();
        } else {
            thereAreManyLetters (count);
        }
    }

    private void thereAreManyLetters (int count) {
        number = count.ToString ();
        pluralModifier = "s";
    }

    private void thereIsOneLetter () {
        number = "1";
        pluralModifier = "is";
    }

    private void thereAreNoLetters () {
        number = "no";
        pluralModifier = "s";
    }

}