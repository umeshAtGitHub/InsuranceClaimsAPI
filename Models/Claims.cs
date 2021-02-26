using System;

namespace InsuranceClaimsAPI.Models
{
    public class Claims
    {
        		

public int MemberID { get; set; }        
public DateTime ClaimDate { get; set; }
public double ClaimAmount { get; set; }
    }
}