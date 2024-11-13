namespace Ordering.Infrastructure.Data.Extensions;

internal class InitialData
{
    public static IEnumerable<Customer> Customers =>
    [
        Customer.Create(CustomerId.Of(new Guid("5C436C48-59A1-4448-AF8C-E359B07B53EA")), "mehmet", "mehmet@gmail.com"),
        Customer.Create(CustomerId.Of(new Guid("839DF924-A605-466D-9309-7EF495A44D6A")), "john", "john@gmail.com"),
    ];

    public static IEnumerable<Product> Products =>
    [
        Product.Create(ProductId.Of(new Guid("0F625855-12A2-4D4A-9337-918663E4EA24")), "IPhone X", 500),
        Product.Create(ProductId.Of(new Guid("BD4AF179-5315-40B0-A97C-9AB2AE71D7A2")), "Samsung 10", 400),
        Product.Create(ProductId.Of(new Guid("20672676-F03A-471B-9DDC-56EC9DB92158")), "Huawei Plus", 650),
        Product.Create(ProductId.Of(new Guid("7751F210-515C-41A9-8C48-EE5B89EA9026")), "Xiaomi Mi", 450),
    ];

    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            var address1 = Address.Of("mehmet", "ozkaya", "mehmet@gmail.com", "Bahcelievler No: 4", "England", "London", "100");
            var address2 = Address.Of("john", "doe", "john@gmail.com", "Broadway No: 4", "Merica", "New York", "101");

            var payment1 = Payment.Of("mehmet", "5555555555", "12/28", "555", 1);
            var payment2 = Payment.Of("john", "66666666666", "06/30", "666", 2);

            var order1 = Order.Create(
                OrderId.Of(new Guid("79D8BDDC-6008-46B1-BD2B-F7A8B0F18030")),
                CustomerId.Of(new Guid("5C436C48-59A1-4448-AF8C-E359B07B53EA")),
                OrderName.Of("ORD_1"),
                shippingAddress: address1,
                billingAddress: address1,
                payment1);
            order1.Add(ProductId.Of(new Guid("0F625855-12A2-4D4A-9337-918663E4EA24")), 2, 500);
            order1.Add(ProductId.Of(new Guid("BD4AF179-5315-40B0-A97C-9AB2AE71D7A2")), 1, 400);

            var order2 = Order.Create(
                OrderId.Of(new Guid("2C1C8136-12E2-44A3-87C0-756A3355C3C1")),
                CustomerId.Of(new Guid("839DF924-A605-466D-9309-7EF495A44D6A")),
                OrderName.Of("ORD_2"),
                shippingAddress: address2,
                billingAddress: address2,
                payment2);

            return [order1, order2];
        }
    }
}
