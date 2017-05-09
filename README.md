# Sloth
You probably already have heard about analytics tools. If you don't know anything about the analytics subject, a easy way to describe it is the fact of taking many differents types of measures about your application. Then, you can use those measures to help you in your decisions. For example, you add a new feature in your application but don't have any feedback about it. It works perfectly and don't have any bugs so nobody talks about it ? Or nobody is using it and you need promote it ? Maybe it's just not useful for your users and have kind of lost your time. Another example is for configuration collecting. You're tired of supporting old version of OS. Is there anybody still using it ? Maybe you're just putting energy to maintain something that your users don't use anymore.

As you can see, analytics can be really useful. There's already a lot of tools out there for web application. However, if you're developing an desktop app, you don't have the same choice. That's where the first main feature of Sloth come from : **Learn** (Analytics). You will know what is the user doing with your app and where to put your energy on even if you don't have clear feedback from users.

The second feature of Sloth, **Repeat**, came from a mix of idea. If you want to do some UI automated testing, or just fix an issue with all informations about what the user exactly did (minus keyboard), this feature is designed for it. You can create a file for testing in two ways : make the scenario first with the **Learn** feature on or write a correctly formatted file.

Last feature of Sloth, **Learn and Repeat**, is basically the combination of both. For example, if you have something to do 100 times, you can learn it the first time and repeat it 99 times. There is no specific method exposed by Sloth to achieve this. You can easily combine the usage of both methods described below to do it.

## Usage

Using Sloth in your project is really easy. After adding sloth.dll as a reference in your project, you only need to start a new listener at your application launch :

```cs
private void StartListening() {
  ISlothListener listener = new SlothListener();
  listener.Start();
}
```
```vb
Private Sub StartListening()
  Dim listener As ISlothListener = New SlothListener()
  listener.Start()
End Sub
```

Then, you can replay what the user did :

```cs
private void ReplayUserActions() {
  ISlothAutomaton automaton = new SlothAutomaton();
  automaton.RepeatBehavior("%LOCALAPPDATA%\Sloth\UserEvent.sloth");
}
```
```vb
Private Sub ReplayUserActions()
  Dim automaton As ISlothAutomaton = New SlothAutomaton()
  automaton.RepeatBehavior("%LOCALAPPDATA%\Sloth\UserEvent.sloth")
End Sub
```
Of course, you can use only one if want. For the automaton, any file with right format can be given as input.

## To Do
- [x] Have a simple prototype working for Windows Forms app
- [x] Have a more complete solution working for at least Windows Forms and WPF app
- [x] Versioning
- [x] Add a concrete example
- [x] Make a decision about acceptance tests
- [ ] Add some filters for learning events
- [ ] Develop some tools to analyse sloth file

## History

The crazy adventure of Sloth all started during Christmas of 2016... :christmas_tree:

The whole idea came from two distincts needs: measurement and automation. In facts, it started with the first one, measurement, and then automation. It could have been two differents projects. However, the possibility of combine both to make a third feature has been the final argument to make it one.

## License

MIT License
