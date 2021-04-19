import 'package:flutter/material.dart';
import 'package:mobile/views/widgets/header_search_box.dart';

class Body extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;

    return SingleChildScrollView(
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          HeaderSearcheBox(size: size)
        ],
      ),
    );
  }
}