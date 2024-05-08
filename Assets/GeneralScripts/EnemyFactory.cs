using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : AbstractFactory<BaseEnemy>
{
    public EnemyFactory(BaseEnemy productToProduce) : base(productToProduce)
    {
    }
    public override BaseEnemy CreateProduct()
    {
        return (BaseEnemy)product.Clone();
    }
}
