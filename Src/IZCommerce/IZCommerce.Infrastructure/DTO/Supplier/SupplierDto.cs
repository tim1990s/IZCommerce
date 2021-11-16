namespace IZCommerce.Infrastructure.DTO.Supplier
{
    public class  SupplierDto
    {
        public int SupplierId { get; set; }

        public string CompanyName { get; set; }

        public string ContactFName { get; set; }

        public string ContactLName { get; set; }

        public string ContactTitle { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string WebSite { get; set; }

        public string PaymentMethods { get; set; }

        public string DiscountType { get; set; }

        public double DiscountRate { get; set; }

        public string TypeGoods { get; set; }

        public bool DiscountAvailable { get; set; }

        public bool CurrentOrder { get; set; }

        public string CustomerID { get; set; }

        public string SizeURL { get; set; }

        public string Logo { get; set; }

        public int Ranking { get; set; }

        public string Note { get; set; }
    }
}
