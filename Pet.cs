namespace ClashPetTheoryCrafting
{
    internal class Pet(string name, string summonerClass, decimal summonCost, int aP, int mP, int hP, decimal hitChance, decimal dodgeChance, int damagePerHit, int utilityScore, int hardSummonLimit, string summonGroup, int summonScore, int summonPointTotal)
    {
        public string Name { get; set; } = name;
        public string SummonerClass { get; set; } = summonerClass;
        public decimal SummonCost { get; set; } = summonCost;
        public int AP { get; set; } = aP;
        public int MP { get; set; } = mP;
        public int HP { get; set; } = hP;
        public decimal HitChance { get; set; } = hitChance;
        public decimal DodgeChance { get; set; } = dodgeChance;
        public int DamagePerHit { get; set; } = damagePerHit;
        public int UtilityScore { get; set; } = utilityScore;
        public int HardSummonLimit { get; set; } = hardSummonLimit;
        public string SummonGroup { get; set; } = summonGroup;
        public int SummonScore { get; set; } = summonScore;
        public int SummonPointTotal { get; set; } = summonPointTotal;

        public decimal AverageDamagePerHit => DamagePerHit * HitChance;
        public decimal DamagePerSummonerMP => AverageDamagePerHit / SummonCost;
        public decimal NumberOfAttacksBeforeGoingPoof => Math.Min(MP, AP);
        public decimal AverageDamageOverLifespan => AverageDamagePerHit * NumberOfAttacksBeforeGoingPoof;
        public decimal LifespanDamagePerSummonerMP => AverageDamageOverLifespan / SummonCost;
        public int HitsToAuraBeforeDeath => (int)Math.Ceiling(Convert.ToDecimal(HP) / Convert.ToDecimal(8));
        public decimal DamageToPreparedTank => HitsToAuraBeforeDeath * HitChance;

        public decimal HardSummonCost => HardSummonLimit * SummonCost;
        public decimal HardSummonAverageDamage => HardSummonLimit * AverageDamagePerHit;
        public decimal HardSummonDamageToPreparedTank => HardSummonLimit * HitsToAuraBeforeDeath * HitChance;

        public int PointCapNum => SummonPointTotal / SummonScore;
        public decimal PointCapCost => PointCapNum * SummonCost;
        public decimal PointCapAverageDamage => PointCapNum * AverageDamagePerHit;
        public decimal PointCapDamageToPreparedTank => PointCapNum * HitsToAuraBeforeDeath * HitChance;

        public string ToString(bool summary)
        {
            if (summary)
            {
                return $"{Name} (Cost={SummonCost}, Attacks={NumberOfAttacksBeforeGoingPoof}): AvgDmg={AverageDamagePerHit:0.##}, DmgPerMP={DamagePerSummonerMP:0.##}, AuraHits={HitsToAuraBeforeDeath}";
            }
            else
            {
                return $@"== {Name} ==
Master: {SummonerClass} @ {SummonCost}MP
Stats:
    - AP: {AP}, MP: {MP}, HP: {HP}
    - Attack/Chance: {HitChance} /Damage: {DamagePerHit}
    - Utility score: {UtilityScore}
Aggregates:
    - Damage Per Hit (avg): {AverageDamagePerHit:0.##}
    - Damage Per Summoner MP spent (avg): {DamagePerSummonerMP:0.##}
    - Number Of Attacks Per Summon: {NumberOfAttacksBeforeGoingPoof:0.##}
    - Average Damage Over Lifespan: {AverageDamageOverLifespan:0.##}
    - Lifespan Damage Per Summoner MP spent: {LifespanDamagePerSummonerMP:0.##}
    - Hits To 8 Damage Aura: {HitsToAuraBeforeDeath}
    - Damage To Prepared Tank: {DamageToPreparedTank:0.##}

New methods:
## Hard cap ##
    - Allowed: {HardSummonLimit}
    - Cost to raise army of size: {HardSummonCost:0.##}
    - Average damage of army: {HardSummonAverageDamage:0.##}
    - Army damage to prepared tank: {HardSummonDamageToPreparedTank:0.##}

## Point cap ##
    - Summoner total: {SummonPointTotal}
    - Per unit: {SummonScore}
    - Number of units in army: {PointCapNum}
    - Cost to raise army of size: {PointCapCost:0.##}
    - Average damage of army: {PointCapAverageDamage:0.##}
    - Army damage to prepared tank: {PointCapDamageToPreparedTank:0.##}";
            }
        }
    }
}
