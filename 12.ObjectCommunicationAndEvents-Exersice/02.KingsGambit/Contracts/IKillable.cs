public interface IKillable
{
    bool IsAlive { get; }

    void Die();
}