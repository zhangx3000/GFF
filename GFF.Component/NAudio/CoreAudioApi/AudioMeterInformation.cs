using GFF.Component.NAudio.CoreAudioApi.Interfaces;
using System.Runtime.InteropServices;

namespace GFF.Component.NAudio.CoreAudioApi
{
    public class AudioMeterInformation
	{
		private readonly IAudioMeterInformation audioMeterInformation;

		private readonly EEndpointHardwareSupport hardwareSupport;

		private readonly AudioMeterInformationChannels channels;

		public AudioMeterInformationChannels PeakValues
		{
			get
			{
				return this.channels;
			}
		}

		public EEndpointHardwareSupport HardwareSupport
		{
			get
			{
				return this.hardwareSupport;
			}
		}

		public float MasterPeakValue
		{
			get
			{
				float result;
				Marshal.ThrowExceptionForHR(this.audioMeterInformation.GetPeakValue(out result));
				return result;
			}
		}

		internal AudioMeterInformation(IAudioMeterInformation realInterface)
		{
			this.audioMeterInformation = realInterface;
			int num;
			Marshal.ThrowExceptionForHR(this.audioMeterInformation.QueryHardwareSupport(out num));
			this.hardwareSupport = (EEndpointHardwareSupport)num;
			this.channels = new AudioMeterInformationChannels(this.audioMeterInformation);
		}
	}
}
