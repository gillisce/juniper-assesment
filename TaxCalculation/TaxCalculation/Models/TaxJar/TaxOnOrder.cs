using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculation.Models.TaxJar
{
	public class TaxJarBodyForOrder
	{
		public string from_country { get; set; }
		public string from_zip { get; set; }
		public string from_state { get; set; }
		public string from_city { get; set; }
		public string from_street { get; set; }
		public string to_country { get; set; }
		public string to_zip { get; set; }
		public string to_state { get; set; }
		public string to_street { get; set; }
		public string to_city { get; set; }
		public double amount { get; set; }
		public double shipping { get; set; }
		public List<LineItems> line_items { get; set; }
		public List<NexusAddress> nexus_addresses { get; set; } = new List<NexusAddress>();
	}


	public class LineItems
	{
		public int quantity { get; set; }
		public double unit_price { get; set; }
		public string product_tax_code { get; set; }
	}

	public class NexusAddress
	{
		public string country { get; set; }
		public string state { get; set; }
		public string zip { get; set; }
	}

    
    public class LineItem
    {
        public double city_amount { get; set; }
        public double city_tax_rate { get; set; }
        public double city_taxable_amount { get; set; }
        public double combined_tax_rate { get; set; }
        public double county_amount { get; set; }
        public double county_tax_rate { get; set; }
        public double county_taxable_amount { get; set; }
        public string id { get; set; }
        public double special_district_amount { get; set; }
        public double special_district_taxable_amount { get; set; }
        public double special_tax_rate { get; set; }
        public double state_amount { get; set; }
        public double state_sales_tax_rate { get; set; }
        public double state_taxable_amount { get; set; }
        public double tax_collectable { get; set; }
        public double taxable_amount { get; set; }
    }

    public class Shipping
    {
        public double city_amount { get; set; }
        public double city_tax_rate { get; set; }
        public double city_taxable_amount { get; set; }
        public double combined_tax_rate { get; set; }
        public double county_amount { get; set; }
        public double county_tax_rate { get; set; }
        public double county_taxable_amount { get; set; }
        public double special_district_amount { get; set; }
        public double special_tax_rate { get; set; }
        public double special_taxable_amount { get; set; }
        public double state_amount { get; set; }
        public double state_sales_tax_rate { get; set; }
        public double state_taxable_amount { get; set; }
        public double tax_collectable { get; set; }
        public double taxable_amount { get; set; }
    }

    public class Breakdown
    {
        public double city_tax_collectable { get; set; }
        public double city_tax_rate { get; set; }
        public double city_taxable_amount { get; set; }
        public double combined_tax_rate { get; set; }
        public double county_tax_collectable { get; set; }
        public double county_tax_rate { get; set; }
        public double county_taxable_amount { get; set; }
        public List<LineItem> line_items { get; set; }
        public Shipping shipping { get; set; }
        public double special_district_tax_collectable { get; set; }
        public double special_district_taxable_amount { get; set; }
        public double special_tax_rate { get; set; }
        public double state_tax_collectable { get; set; }
        public double state_tax_rate { get; set; }
        public double state_taxable_amount { get; set; }
        public double tax_collectable { get; set; }
        public double taxable_amount { get; set; }
    }

    public class Jurisdictions
    {
        public string city { get; set; }
        public string country { get; set; }
        public string county { get; set; }
        public string state { get; set; }
    }

    public class Tax
    {
        public double amount_to_collect { get; set; }
        public Breakdown breakdown { get; set; }
        public bool freight_taxable { get; set; }
        public bool has_nexus { get; set; }
        public Jurisdictions jurisdictions { get; set; }
        public double order_total_amount { get; set; }
        public double rate { get; set; }
        public double shipping { get; set; }
        public string tax_source { get; set; }
        public double taxable_amount { get; set; }
    }
    public class TaxOnOrderResponseObject
    {
        public Tax tax { get; set; }
    }
}
