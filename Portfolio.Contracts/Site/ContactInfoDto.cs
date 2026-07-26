namespace Portfolio.Contracts.Site;

public record ContactInfoDto(
	string Email,
	string Phone,
	AddressDto Address);