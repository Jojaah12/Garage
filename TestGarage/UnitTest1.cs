using Garage;

namespace GarageTests
{
    [TestClass]
    public class GarageTests
    {
        [TestMethod]
        public void ParkVehicle_WhenGarageIsNotFull_ShouldParkVehicle()
        {
            // Arrange
            Garage<Vehicle> garage = new Garage<Vehicle>(10);
            Vehicle vehicle = new Car("ABC123", "Red", 4, 5);

            // Act
            garage.ParkVehicle(vehicle);

            // Assert
            Assert.AreEqual(1, garage.Count);
        }

        // More test methods for other public methods of the Garage class...
    }
}