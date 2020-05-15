
using System.Collections;

public interface IHitable
{
    void TakeDamage (int damage);
    
}
public interface IKillable
{
    void Die ();
}