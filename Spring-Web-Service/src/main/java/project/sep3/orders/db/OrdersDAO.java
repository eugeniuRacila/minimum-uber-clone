package project.sep3.orders.db;


import java.util.List;

public interface OrdersDAO {
    Order create(int customerId, String startingPoint, String destinationPoint, String typeOfCar, int amountOfSeats);
    List<Order> readAll();
}
