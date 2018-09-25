public abstract class Employee {
    public abstract bool isPayday ();
    public abstract Money calculatePay ();
    public abstract void deliverPay (Money pay);

    //---
    public interface EmployeeFactory {
        public Employee makeEmployee (EmployeeRecord record);
    }

    //---
    public class EmployeeFactoryImpl : EmplyeeFactory {
        public Employee makeEmployee (EmployeeRecored recored) {
            switch (recored.Type) {
                case COMMISSIONED:
                    return new CommissionedEmplyee (recored);
                case HOURLY:
                    return new HourlyEmployee (recored);
                case SALARIED:
                    return new SalariedEmployee (recored);
                default:
                    throw new InvalidEmplyeeType (recored.Type);
            }
        }
    }
}