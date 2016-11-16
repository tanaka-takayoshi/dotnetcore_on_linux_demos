# Summary
OpenShift provides [secrets](https://docs.openshift.com/enterprise/3.2/dev_guide/secrets.html) feature. It provides a mechanism to hold sensitive information. We can conminate OpenShift secrets and ASP.NET Core configuration system. OpenShift provides [ASP.NET Core S2i](https://github.com/openshift-s2i/s2i-aspnet-example).

# Steps
1. Create secret with json file.
 ```
 $ vim mysecret.yaml
 apiVersion: "v1"
 kind: "Secret"
 metadata:
   name: "mysecret"
 stringData: 
   mysecretkey: "ValueOfMySecret"

 $ oc create -f mysecret.yaml
 ```
 
2. Deploy this repository to OpenShift.
 If you haven't created application template, please create.
 ```
 $ git clone https://github.com/openshift-s2i/s2i-aspnet-example
 $ oc create -f templates/aspnet-s2i-template.json -n openshift
 ```
 
 ```
 $  oc new-app --template=aspnet-s2i  -p GIT_URI=https://github.com/tanaka-takayoshi/rhte2016-apac-demo-dotnetcore -p  GIT_CONTEXT_DIR="OpenShift/04_Working_with_OpenShift_Secrets" -p APPLICATION_NAME=<APP_NAME> -l app=<APP_NAME>
 ```

3. Edit deploymentconfig to add secret.
 ```
 $ oc volumes dc/<APP_NAME> --add --type=secret --secret-name=mysecret --mount-path=/etc/secret-volume
 ```
