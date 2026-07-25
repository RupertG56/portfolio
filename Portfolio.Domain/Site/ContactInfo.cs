namespace Portfolio.Domain.Site;

public sealed class ContactInfo(string email,
        string phone, Address address)
{
    public string Email { get; set; } = email;
    public string Phone { get; set; } = phone;
    public Address Address { get; set; } = address;
}
