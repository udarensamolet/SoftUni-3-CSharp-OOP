﻿namespace ExplicitInterface.Contracts
{
    public interface IPerson
    {
        string Name { get; }    
        int Age { get; }

        void GetName();
    }
}
