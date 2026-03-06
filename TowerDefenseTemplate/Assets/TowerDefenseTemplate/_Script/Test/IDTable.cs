public static class IDTable
{
    public const int INSTANCE_MODULUS = 100;
    /* 
     * Modulus 100 to get Instance ID
     * ID = 10x = 100
     * Stats 
     */
    public const int ENERGY = 100;
    public const int HEALTH = 200;
    public const int ENERGY_COST = 1100;
    public const int FIRE_FREQUENCY = 1200;
    public const int ENERGY_RECHARGE_PERIOD = 1300;
    public const int ENERGY_REGEN_RATE = 1400;
    public const int DAMAGE = 2100;
    public const int LIFE_TIME = 2200;
    public const int SPEED = 2300;

    /* 
     * Object
     */
    public const int WEAPON = 1000;
    public const int BULLET = 2000;

    /* 
     * Flags
     */
    public const int CAN_FIRE = 1;

    /* 
     * Offset
     */
    public const int FIRE_POINT = 100;

    /*
     * States
     */
    public const int STATES = 1000;
    public const int STATES_BEHAVIOUR = 2000;
    public const int STATES_CHECK_CONDITION = 3000;
    public const int STATES_TRANSITION = 4000;
}