using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Vision.V1;
using static Google.Cloud.Vision.V1.AnnotateImageRequest;


namespace PorkPork
{
    class googleVision
    {
        public googleVision()
        {
            
        }

        public AnnotateImageResponse AnalyzeImage(Image image)
        {
            var client = new ImageAnnotatorClientBuilder();
            client.CredentialsPath = ("HackGT.json");
            var visClient = client.Build();

            AnnotateImageRequest request = new AnnotateImageRequest
            {
                Image = image,
                Features =
                {
                    new Feature { Type = Feature.Types.Type.LabelDetection},
                    new Feature { Type = Feature.Types.Type.LogoDetection},
                    new Feature { Type = Feature.Types.Type.ImageProperties}
                }  
            };

            return visClient.Annotate(request); 
        }
    }
}
