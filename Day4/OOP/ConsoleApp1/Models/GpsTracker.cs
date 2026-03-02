namespace OOP.Models
{
	public class GpsTracker
	{
		public string GetCurrentLocation()
		{
			// In a real implementation, this method would interface with GPS hardware
			// to retrieve the current location. For this example, we'll return a dummy location.
			return "Pune,Maharashtra";
		}
	}
}