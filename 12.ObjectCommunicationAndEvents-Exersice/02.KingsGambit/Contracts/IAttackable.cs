﻿public delegate void GetAttackedEventHandler();

public interface IAttackable
{
    event GetAttackedEventHandler GetAttackedEvent;

    void GetAttacked();
}