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
		public List<NexusAddress> nexus_addresses { get; set; }
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


	public class TaxOnOrderResponse
	{
		public double amount_to_collect { get; set; }
		public double order_total_amount { get; set; }
		public double rate { get; set; }
		public double shipping { get; set; }
		public string tax_source { get; set; }
		public double taxable_amount { get; set; }
	}
}
