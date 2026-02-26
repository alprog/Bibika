
using System.Collections.Generic;

public class GameState : Singleton<GameState>
{
    public List<Car> Cars;

    private GameState()
    {
        GenerateRandomCars(10);
    }

    public void Update(float deltaTime)
    {
    }

    private void GenerateRandomCars(int count)
    {
        Cars = new List<Car>();
        for (int i = 0; i < count; i++)
        {
            var car = new Car();
            car.Randomize();
            Cars.Add(car);
        }
    }
}
