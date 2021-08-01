# Optimizing a lambda layer can only be done on Amazon Linux 2 distributions.
FROM amazonlinux:2

# Install git, zip, add the microsoft packages repository and install both the 5.0 sdk and Lambda tools.
RUN yum update -y && yum install -y git && yum install -y zip && rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm && yum install -y dotnet-sdk-5.0 && dotnet tool install -g Amazon.Lambda.Tools

# The value of these 2 build args are passed when running 'docker build'
ARG access_key \
secret_key

# Assign the build args to the environment variables (our AWS credential source)
ENV AWS_ACCESS_KEY_ID=$access_key \
AWS_SECRET_ACCESS_KEY=$secret_key

# Clone the content of the demo repository
RUN git clone https://github.com/bschaatsbergen/pre-jitted-dotnet-lambda-layer.git

# The 'Dependencies.csproj' is stored under the '/Dependencies' directory
WORKDIR /pre-jitted-dotnet-lambda-layer/Dependencies

# '~/.dotnet/tools/dotnet-lambda' 
RUN ~/.dotnet/tools/dotnet-lambda publish-layer Dependencies --layer-type runtime-package-store --framework netcoreapp3.1 --s3-bucket bruno-lambda-layer-demo --enable-package-optimization true --region eu-central-1