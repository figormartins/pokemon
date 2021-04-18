import 'package:flutter/material.dart';
import 'package:mobile/utils/app_routes.dart';
import 'package:mobile/views/pokemons_overview_screen.dart';

void main() => runApp(MyApp());

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: PokemonsOverviewScreen(),
    );
  }
}