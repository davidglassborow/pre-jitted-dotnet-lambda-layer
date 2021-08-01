# pre-jitting in .NET Lambda

Pre-compiling some of our assemblies and wrapping it in a Lambda layer. This is a demo repository for one of my articles: https://www.bschaatsbergen.com/pre-jitted-dotnet-lambda

## Publish the layer

Navigate to the /Dependencies directory

```bash
dotnet lambda publish-layer Dependencies --layer-type runtime-package-store --s3-bucket my-lambda-layer-bucket --framework netcoreapp3.1 --enable-package-optimization true
```

# What are we trying to solve?

Cold starts, here an example of a cold start from a Lambda function that does not use pre-jitted .NET assemblies.

```bash
2021-07-30T22:38:25.121+02:00	START RequestId: 583a2051-69bc-4c8a-883f-0761b0c11214 Version: $LATEST
2021-07-30T22:38:26.065+02:00	Function.Handler() => Incoming request: {"Name":"Bruno","Address":"MyLambdaLayerStreet 123"}
2021-07-30T22:38:26.083+02:00	Handler.Handle() => Reached handler.
2021-07-30T22:38:26.084+02:00	END RequestId: 583a2051-69bc-4c8a-883f-0761b0c11214
2021-07-30T22:38:26.084+02:00	REPORT RequestId: 583a2051-69bc-4c8a-883f-0761b0c11214 Duration: 962.54 ms Billed Duration: 963 ms Memory Size: 256 MB Max Memory Used: 72 MB Init Duration: 232.83 ms
```

## Usage

Deploy the function by referencing the publisher lambda layer ARN from the output of the 'dotnet lambda publish-layer' command.

```bash
dotnet lambda deploy-function SampleLambda --function-layers arn:aws:lambda:eu-central-1:782347423781:layer:Dependencies:1 
```

Below the logs from the same Lambda function using the pre-jitted Lambda layer.

```bash
2021-07-30T22:54:39.235+02:00	START RequestId: c1d5ba5e-7779-407d-a92e-c33c4fcea096 Version: $LATEST
2021-07-30T22:54:39.830+02:00	Function.Handler() => Incoming request: {"Name":"Bruno","Address":"MyPreJittedLambdaLayerStreet 123"}
2021-07-30T22:54:39.848+02:00	Handler.Handle() => Reached handler.
2021-07-30T22:54:39.849+02:00	END RequestId: c1d5ba5e-7779-407d-a92e-c33c4fcea096
2021-07-30T22:54:39.849+02:00	REPORT RequestId: c1d5ba5e-7779-407d-a92e-c33c4fcea096 Duration: 613.28 ms Billed Duration: 614 ms Memory Size: 256 MB Max Memory Used: 73 MB Init Duration: 218.69 ms
```

## Questions

Raise questions as issues or ping me.