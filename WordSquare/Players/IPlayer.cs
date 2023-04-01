﻿using WordSquare.ValueObjects;

namespace WordSquare.Players;
public interface IPlayer
{
    void EndTurn();
    bool HasActions();
    bool IsSecondAction();
    void SkipAction();
    void FirstAction(Coord coord);
    char SecondAction(char letter, Coord coord);
}
