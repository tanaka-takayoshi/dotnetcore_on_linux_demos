# Summary
Simple step for ASP.NET Core OpenShift s2i.

# Steps
1. Create template
 ```
 $ oc create -f https://raw.githubusercontent.com/openshift-s2i/s2i-aspnet-example/master/templates/aspnet-s2i-template.json -n openshift
 ```

2. Create app with empty ASP.NET Core web.
 ```
 $ oc new-app --template=aspnet-s2i -p APPLICATION_NAME=aspnet-s2-demo,GIT_URI=https://github.com/tanaka-takayoshi/s2i-aspnet-example -l app=aspnet-s2-demo
 ```

 Or you can use your own repository. At first fork this repository is good choice. If you want to try next GitHub Webhook step, please use your own repository.
 ```
 $ oc new-app --template=aspnet-s2i -p APPLICATION_NAME=aspnet-s2-demo,GIT_URI=https://github.com/<your_account>/s2i-aspnet-example -l app=aspnet-s2-demo
 ```

3. GitHub Webhook
GitHub Webhook URI is returned by ``describe`` command.

```
$ oc describe bc simpletodo
```

Follow the [GitHub setup instructions](https://developer.github.com/webhooks/creating/#setting-up-a-webhook) to paste the webhook URL into your GitHub repository settings.
Then commit and push something.
