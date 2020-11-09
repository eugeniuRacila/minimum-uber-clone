package project.sep3.orders.db;

import org.hibernate.annotations.CacheConcurrencyStrategy;

import javax.persistence.*;

@Entity
@Table(name="orders")
@Cacheable
@org.hibernate.annotations.Cache(usage = CacheConcurrencyStrategy.READ_WRITE)
public class Order {
    @Id
    @Column(name = "id")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic
    private Integer id;
    @Column(name="customer_Id", nullable=false)
    private int customerId;
    @Column(name="driver_Id")
    private int driverId;
    @Column(name="starting_Point", nullable = false)
    private String startingPoint;
    @Column(name="destination_Point", nullable = false)
    private String destinationPoint;
    @Column(name="type_Of_Car", nullable = false)
    private String typeOfCar;
    @Column(name = "amount_Of_Seats", nullable = false)
    private int amountOfSeats;

    public Order() {}

    public void setCustomerId(int customerId) {
        this.customerId = customerId;
    }

    public void setDriverId(int driverId) {
        this.driverId = driverId;
    }

    public void setStartingPoint(String startingPoint) {
        this.startingPoint = startingPoint;
    }

    public void setDestinationPoint(String destinationPoint) {
        this.destinationPoint = destinationPoint;
    }

    public void setTypeOfCar(String typeOfCar) {
        this.typeOfCar = typeOfCar;
    }

    public void setAmountOfSeats(int amountOfSeats) {
        this.amountOfSeats = amountOfSeats;
    }

    public int getCustomerId() {
        return customerId;
    }

    public int getDriverId() {
        return driverId;
    }

    public String getStartingPoint() {
        return startingPoint;
    }

    public String getDestinationPoint() {
        return destinationPoint;
    }

    public String getTypeOfCar() {
        return typeOfCar;
    }

    public int getAmountOfSeats() {
        return amountOfSeats;
    }
}
