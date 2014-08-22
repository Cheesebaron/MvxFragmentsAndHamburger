MvxFragmentsAndHamburger
========================

Sample showing Fragments and Hamburger menu working.

It uses recently added Fragment rehydration and save state support in [my fragments branch of MvvmCross](https://github.com/Cheesebaron/MvvmCross/tree/fragments).

How to test it works
--------------------

Start the app. You will be met with the Hamburger menu expanded. There are two ViewModels to choose between.

1. FirstView, which is associated to FirstViewModel does nothing with the Properties in the ViewModel when the app is tombstoned, nothing is saved.
2. SecondView, which is associated to SecondViewModel does the opposite of FirstViewModel, it saves its Properties in the SaveState() method, which is a default way to save state in MvvmCross ViewModels.

There are a couple of scenarios to test out.

1. Visit both Views and populate them with values. Now pressing the home button on the device will background the application. When you return to the app, both ViewModels should be repopulated if you didn't leave the app in background for a long time and the device needed the memory. Otherwise scenario 2. will happen.
2. Visit both Views and populate them with values. Now pressing the back button should terminate the app, or destroy the Activity. When you return to the app by selecting it in the recents or from elsewhere, only SecondViewModel should be repopulated with the data saved.

Cool, eh?
