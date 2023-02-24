using MilitaryElite.Enums;

namespace MilitaryElite.Contracts
{
    public interface IMission
    {
        string CodeName { get; }
        MissionState State { get; }
    }
}
