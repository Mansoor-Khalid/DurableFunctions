docker:
docker build -t mansoorkhalid2020/durable-functions .
docker push mansoorkhalid2020/durable-functions

k8:
kubectl apply -f k8-deploy.yaml
kubectl apply -f k8-secrets.yml
kubectl apply -f k8-service.yml	
kubectl apply -f k8-kedascaler-triggerauth.yml
kubectl apply -f k8-kedascaler-scaledobject.yml