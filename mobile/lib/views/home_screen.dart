import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import 'package:mobile/utils/constants.dart';
import 'package:mobile/views/widgets/body.dart';

class HomeScreen extends StatefulWidget {
  @override
  _HomeScreenState createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        elevation: 0,
        leading: IconButton(
          padding: EdgeInsets.only(left: kDefaultPadding),
          icon: SvgPicture.asset("assets/icons/menu.svg"),
          onPressed: (){},
        ),
      ),
      body: Body(),
    );
  }
}
