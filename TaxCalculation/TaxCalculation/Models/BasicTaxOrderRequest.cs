using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculation.Models
{

	public class BasicTaxOnOrderRequest
	{
		public string FromCountry { get; set; }
		public string FromZip { get; set; }
		public string FromState { get; set; }
		public string FromCity { get; set; }
		public string FromStreet { get; set; }
		public string ToCountry { get; set; }
		public string ToZip { get; set; }
		public string ToState { get; set; }
		public string ToStreet { get; set; }
		public string ToCity { get; set; }
		public double Amount { get; set; }
		public double Shipping { get; set; }
	}


	public class GenericLineItems
	{
		public int Quantity { get; set; }
		public double UnitPrice { get; set; }
		public string TaxCode { get; set; }
	}

	public class GenericNexusAddress
	{
		public string Country { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
	}


	//We could map more fields if the requirments call for it.
	//For the time being I just grabbed a handful of the ones that seemed generic enough that it would come from any service
	public class BasicTaxOnOrderResponse
	{
		public double AmountToCollect { get; set; }
		public double OrderTotal { get; set; }
		public double TaxRate { get; set; }
		public double Shipping { get; set; }
		public string TaxSource { get; set; }
		public double TaxableAmount { get; set; }
	}
}
