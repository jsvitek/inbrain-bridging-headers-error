# inbrain-bridging-headers-error
An empty Unity 2020.3.38.f1 project which includes:
- ExternalDependencyManager 1.2.172
- IronSource 7.3.0.1
- InBrain 2.0.0

This serves as a demo for reproducing issue discussed [here](https://github.com/inbrainai/unitysdk/issues/2).

The combination above causes Xcode to throw error `Using bridging headers wtih framework targets is unsupported` while generating the iOS build (ipa).
The build process will finish because the emitted error won't return a nonzero exit code and the app will run, but when using Fastlane in automated pipelines this error prevents a job from finishing successfully and subsequent jobs (deployment for instance) will not run.
