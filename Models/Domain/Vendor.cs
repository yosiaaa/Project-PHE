namespace ProjectSupplyManagement.Models.Domain
{
	public class Vendor
	{
		public Guid Id { get; set; }
		public string CompanyName { get; set; }
		public string CompanyEmail { get; set; }
		public string PhoneNumber { get; set; }
		public string Photo { get; set; } // You can store the image path or a URL
		public string BusinessSector { get; set; }
		public string TypeOfCompany { get; set; }
		public bool IsApproved { get; set; }
	}
}
