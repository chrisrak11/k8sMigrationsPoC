## Minikube

```shell
minikube start --hyperv-use-external-switch --driver=docker --docker-env=local
```

```shell
minikube dashboard
```

## Apply YAML
1) Apply ```permissions.yaml``` to set up a Service Account and its roles
```shell
kubectl apply -f .\permissions.yaml
```

2) Apply ```job.yaml``` (mimics a migration running for 20 seconds)
```shell
kubectl apply -f .\job.yaml
```

3) Apply ```aspnetcore_sample.yaml``` (mimics a long-running main application)
```shell
kubectl apply -f .\aspnetcore_sample.yaml
```

## Updating image
```shell
docker build -t dummytoggle-image . 
```

```shell
docker image tag dummytoggle-image:latest chrisrak11/dummytogglerepo:latest
```

```shell
docker image push chrisrak11/dummytogglerepo:latest
```
