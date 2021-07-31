FROM amazonlinux:2

RUN yum update -y && yum install -y git && yum install -y zip && rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm && yum install -y dotnet-sdk-5.0 && dotnet tool install -g Amazon.Lambda.Tools

ARG access_key \
secret_key

ENV AWS_ACCESS_KEY_ID=$access_key \
AWS_SECRET_ACCESS_KEY=$secret_key

RUN git clone https://github.com/bschaatsbergen/pre-jitted-dotnet-lambda-layer.git

WORKDIR /pre-jitted-dotnet-lambda-layer/Dependencies

COPY ["Dependencies/Dependencies.csproj", "src/Dependencies/"]

RUN ~/.dotnet/tools/dotnet-lambda publish-layer Dependencies --layer-type runtime-package-store --framework netcoreapp3.1 --s3-bucket bruno-lambda-layer-demo --enable-package-optimization true --region eu-central-1