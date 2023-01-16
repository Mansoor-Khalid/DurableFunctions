
k8-deploy:
- Project Azure Func .net7
  docker:
  docker build -t mansoorkhalid2020/durable-functions .
  docker push mansoorkhalid2020/durable-functions

- kubectl apply -f k8-deploy.yaml
-----------------------------------
k8-Keda:
-----------------------------------
#Note: No use as of yet
kubectl apply -f k8-service.yml	
-----------------------------------
https://keda.sh/docs/2.0/concepts/authentication/
https://keda.sh/docs/2.0/authentication-providers/secret/

kubectl apply -f k8-secrets.yml
kubectl apply -f k8-kedascaler-triggerauth.yml

https://keda.sh/docs/2.0/scalers/azure-storage-queue/
https://keda.sh/docs/2.0/concepts/scaling-deployments/
kubectl apply -f k8-kedascaler-scaledobject.yml