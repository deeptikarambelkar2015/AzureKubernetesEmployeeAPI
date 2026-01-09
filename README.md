Login to Azure:
az login

ACR NAME : 08jandemo.azurecr.io
Command : az acr login --name <<ACR name>>
What was executed :  az acr login --name 08jandemo.azurecr.io

--------------------------------------------------------------------------------------------------------------
Build and push an ARM64 image

docker buildx build --platform linux/arm64 -t 08jandemo.azurecr.io/employeeapi:v1 -f Dockerfile --push .

---------------------------------------------------------------------------------------------------------------

Register the Resource Group to use the namespace :  Microsoft.ContainerService

az provider register --namespace Microsoft.ContainerService

--------------------------------------------------------------------------------------------------------
Create image pull secret:

az aks get-credentials --resource-group RG24Dec --name 08DemoApp
kubectl create secret docker-registry acr-secret --docker-server=08jandemo.azurecr.io --docker-username=08JanDemo --docker-password=d0nGb7C9/maPj9yYrXSIyGr3YVOQzTT/q1iR2zb1CB+ACRChh5qV --docker-email=deepti.karambelkar2015@gmail.com 

---------------------------------------------------------------------------------------------------------------

Then apply kubernetes yaml file : kubectl apply -f .


-------------------------------------------------------------------------------------------------------------

Error : ImageBackOff was encountered initially and this is how we checked the platform mismatch

Use the following commands to check a platform mismatch



az acr manifest list-metadata --registry 08jandemo --name employeeapi -o table


Linux / amd64

-------------------------------------------------------------------------------

kubectl get pod employeeapi-deployment-54bf97f88f-zfhhc -n default -o wide
kubectl describe node aks-agentpool-20056985-vmss000001 | egrep -i "Operating System|Architecture|OS Image|containerRuntime"

Linux / arm64

///////////////////////////////////////////////STOP AKS WHEN NOT IN USE ///////////////////////////////////////////////////

To Stop AKS :
az aks stop --name <cluster-name> --resource-group <resource-group>
EXAMPLE : az aks stop --name 08DemoApp --resource-group RG24Dec
To restart AKS :
az aks start --name <cluster-name> --resource-group <resource-group>

Update ACR to basic

az acr update --name <registry-name> --sku Basic
