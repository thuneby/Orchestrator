namespace DataAccess.DataAccess
{
    public class MasterDataRepository
    {
        public bool IsValidPbsNumber(string pbsNumber)
        {
            return pbsNumber.Trim() switch
            {
                "00015733" => true,
                "12345678" => true,
                _ => false
            };
        }
    }
}
