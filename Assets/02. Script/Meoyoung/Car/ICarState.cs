public interface ICarState
{
    public void OnStateEnter(CarController controller);
    public void OnStateUpdate();
    public void OnStateExit();
}