# Install Free SSL Certification On Your Website

## Introduction

```
Let’s Encrypt is a free, automated, and open certificate authority (CA), run for the public’s benefit. It is a service provided by the Internet Security Research Group (ISRG).
```

## Environment

**Server: Centos 7.0**

 ## Prerequisites

- An availabe website deployed on a server
- A domain name can be resolved by DNS Server
- Web Server like `Nginx`, `Apache` , etc.

## Choose Your  System and Web Server 

![Imgur](https://i.imgur.com/lFFdNdE.png)

Let's Encrypt suppiles automatically deployment by using `Certbot`.

Here is the link.

 [Click Here For Certbot](https://certbot.eff.org/)

## Just a few Commands

```
$ sudo yum install python2-certbot-nginx
$ sudo certbot --nginx 
```

Add `certonly` if you would like to confgure Nginx manually.

 

## Renewal

- Automatically

```
$ sudo certbot renew --dry-run
```

- Manually

```
certbot renew
```

- Cron Job

```
0 0,12 * * * python -c 'import random; import time; time.sleep(random.random() * 3600)' && certbot renew 
```

## Troubles may be Encountered

If you are using a static site generator, `Hugo`, for example, make sure that the url of your site begins with `https://`. Some sites' CSS are found to be prone to lose after SSL certification.