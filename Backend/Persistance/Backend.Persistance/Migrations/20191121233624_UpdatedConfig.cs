using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Persistance.Migrations
{
    public partial class UpdatedConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_ExerciseTypes_ExerciseTypeId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Trainings_TrainingId",
                table: "Exercises");

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("0039c7d2-5318-4013-adb6-1131e834811a"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("06ba0d49-31e4-4579-82cb-fe19325d7728"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("0c71916b-0c5d-4029-b36c-1ba2d297a718"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("1326ef2f-8770-437e-9216-fd7ea9244ea2"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("171e2c85-3ad2-4dfb-ac60-248df83a2ff1"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("1744f222-5e38-48a9-9325-d12cb265a58b"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("1a07c14f-835f-430d-a42b-3025d59f9e33"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("1a236b1e-37fa-47ba-97fb-a81f89644fd9"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("2177e925-ba93-4af0-9238-b01a32267e68"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("22dfe93e-6927-487e-8224-e4ae6b515034"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("26129fce-56a5-4bc5-97f2-7839613d86e1"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("33a4c87f-5ce3-4595-be49-9401e82fbeaa"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("363c26a8-7c85-4062-8406-51fccf827c7d"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("371f4c8d-653c-42b7-a361-50e2350fdd1a"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("3858d919-87cc-4be6-a555-9d94923fae40"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("39cf222b-c876-4667-89ff-fb90ce2ae282"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("3d06fee6-9940-4cc0-a39c-2316f1683a26"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("44300df8-f801-4aa9-95ae-452a0d1f702b"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("45042074-e203-4de5-b8c1-c23cfb703c44"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("46096fba-5300-4af6-b890-87f1a744a38f"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("4814b90d-94cf-4352-9b1c-6a43c748189f"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("49536ae6-eca0-4620-842b-974e0cad0eb9"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("4978ff09-4ecc-4951-b2f6-cb7a6f2f4c6a"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("4fa59c2f-5e62-4560-982d-d6160da7bffc"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("519ad5ef-652f-498b-91cf-db9a12697252"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("52d66d57-e413-42ca-9cfd-2adfda7c6f6a"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("5bc2135d-6ff9-4d8a-b04c-d1a2b7c261c1"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("5bd57b6e-6a37-4d14-95fa-300d47270582"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("5efc3582-b3dd-4df2-9c9a-504f760f8fa2"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("6662d01f-ef27-4344-a40e-c27be8a71356"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("66f7f39f-0dc0-4a2d-b0d7-7c8ab7f0d1dd"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("6c591faa-b3ea-4925-a6b9-a8268c0d972a"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("6dbaadd5-5483-4438-ae6b-96a136cc8ec8"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("6ec90a7c-94a5-4b3b-b1a6-fc9fcfa05c72"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("6f033179-9032-4d99-91a8-30fccb262823"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("6fdf962f-5b8d-401c-981d-e3dbf7e93f62"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("70b17f9b-0500-42d4-accf-b4108c530efa"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("754f60e0-c7b2-41d1-92bd-db63ed3f9f41"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("82a31169-9743-4df3-8815-e042b4573959"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("861fbf4c-7ea1-443c-b0e0-4f42c73c9bbb"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("869337d6-79ad-4fb6-9b29-3dda98fd8cba"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("87e4fa1b-b4fc-497f-98b0-98073c27ec3e"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("8a8e9a6c-4382-4b25-b7ae-da63fd0492d7"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("8bf12041-02a9-4f55-b660-b2aae458dcf1"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("9a58b221-fb06-4662-8f11-8808fe44e5a9"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("9b38d7fb-69ec-4541-b71a-e77ac4ab9659"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("9bf25426-3d28-4481-a9b9-871056470eb9"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("9ec77833-7b5d-4b4c-a649-a765fa5d1a47"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("a0583345-ec50-4265-8c3c-61b19e1fd73f"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("a42e99ff-3074-4996-8cb2-47d902ad54da"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("a8a65c2d-b86b-4c7d-8cc3-c7e611d53f29"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("ad47d0e0-17eb-4583-9e21-0b1c9bc5c129"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("b0dce029-9b4e-439b-8a4f-3396557e8793"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("b13d2328-6b61-48ab-87af-7f5876bcd2b3"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("b18b3207-ace1-4efb-ac25-c42d12cdc588"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("b321bc88-6621-42de-8f10-bfb0d629fe7d"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("b71545ea-e4df-4df8-9d9e-c71624899a45"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("b784c244-64d1-4163-b51d-f284da419c04"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("c5b3da9d-7230-438b-b973-f6ae3493b194"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("c6eb48ae-6ea3-4b10-9f17-bffa758c6506"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("c7d509f7-93a8-44ed-b12a-9fa2483f4122"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("c93153a6-005a-4baa-a0d5-eda1126487d1"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("c936cdfd-16e1-4fa6-b877-2fb91488fe1b"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("c98ef81b-2ae0-4cd1-bea6-b16641771da9"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("ce5b77f8-a558-4abd-a605-1bd5d6a5d334"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("cefe2c33-0ffb-4298-b1b6-918d6c0bddc6"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("da8d4e95-4c4d-408e-8fef-9c5f30470dec"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("dbbe1803-e12d-4af7-bcf6-c1a7ce024bbb"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("dd652174-3a5f-4d1f-a5ee-0a858f493766"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("de49183f-4347-49a2-9511-51927bef1fef"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("defc4d0d-5bc5-48c1-8d9d-f3ea0b67712c"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("e11f1eef-d66b-463a-a0f8-52de5b9e5a1c"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("e4b76eb1-5e9e-4392-b9e7-8677769571cd"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("e5ca9b0e-7529-4de3-b00d-f3f78fc5f965"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("eab45774-3831-4760-8edc-5e414589d611"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("f2afb5a1-e3ed-48bc-bdd4-c1999c951e54"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("f32234c7-2a80-4083-b764-83d3108364e9"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("f45141f0-cac0-4660-80fc-848eeb593d5e"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("fbd037d8-a32e-4687-9b03-d935cffa7c32"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("fe91a6d9-a8cd-494e-b4bb-0f0c3ee1caf7"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("0b075622-ad21-4dec-a3a2-db9d2e34f15a"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("0cc23d87-529f-42e4-b0a0-e9bfb07f75fa"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("247ed77d-5598-4825-be8e-53b516ceed8a"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("28ef3559-2ca2-47a9-933f-8492421aa25c"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("3bf74098-ded5-44bf-9dfe-d5c8898c37bc"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("5bc9c3e8-36be-4873-be0a-1c9148fb230f"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("63a59103-8213-49b4-b041-f53cf433a97e"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("913130b2-8a6d-42f2-b447-f536c7d2a117"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("9664b679-f797-44f6-9e22-42aadb1a67ce"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("c534ee5d-085f-4738-8870-a1e95b7c1bd8"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("ee5186a2-6c22-4716-b0dc-2e7449153c36"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("fb8b2a28-7535-4396-a472-2fa7cfc38901"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("001a60fc-2c7e-4e79-be11-2a366846c2f4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("015624f3-3ddc-4bc3-8df7-e12b8e9050a2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("01eaa38d-abb9-49ac-9ae2-903f30536971"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("026e293b-1ad6-4669-aef2-4eb310baed96"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("02a4a3d7-48f9-46b6-a865-1b80350b758a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("03ee3d7b-d48b-4407-9a60-5119628b429a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("03f77a08-4896-4177-ab5a-e8a29bf720db"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("03f81890-e1f1-4a8c-8f8b-705f56d1ed57"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("041e0c60-d3d2-4d8e-883a-3abf3e2ca56f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("084db1a2-1742-4368-8d04-527c20424f0c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0d4a4248-5ce5-4ab8-a0ec-4c603972b2d4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0e56dc17-77e7-4be1-8f7a-76ad0fc53d6b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0fb36bfc-27b4-479a-89d1-9ca0ffb8bc10"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0ff46d56-eee8-4bb9-9d21-6cc12c890b84"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("11828ba3-4e84-45f4-ad3f-1c0a1ce3e510"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("121b3d46-6e3a-437f-a72f-3040ad26e4dc"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("13c67799-3d6f-468d-b83e-4b1c1b93224c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("13dfab50-e221-40c0-abfb-aaf1e19cb04f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("14185fc6-ec2a-4690-8a59-7ed54098c33f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("154f3f50-f620-410f-b465-8b3ad818d601"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1688e621-a094-478f-99cd-b18270fd7428"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("16d6e49c-684d-42f5-b7c6-84bce3fd57a3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("18a500f4-c8b3-4ae8-be11-c8756b5c910f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1a6f5ce7-7c2e-401b-8911-0294d14447c9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1c59c9ef-6e71-402f-85c1-3141587a1afb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1d4f801f-3ac0-4e80-9f4c-46379c011e9a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1f787679-18bb-4775-8896-699360cb8aad"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1f8b6382-a05c-4305-876f-56356345925c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1fa090c9-f760-46e1-bf4b-c276e79bf36b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("202dbcb6-e042-488f-bd47-e90ecf2aebe1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("24ce0d25-f0bc-42f5-9f9f-b660ee6b6cf2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("24d4349a-a2c5-484a-b442-32be0734ccee"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("25ec903c-c75d-42bd-9f6b-c60e8f357bca"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2651239c-2b25-40f4-b139-65c282173730"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("26ef65f4-d8bd-4792-bf41-d89e99daeb6d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("277f579b-4238-403b-b23f-f5e319e65c5f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("27908afc-facb-4f29-878b-63188773c135"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2866383e-91c9-4514-a4aa-11fd97ea9fae"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("295d2b61-14e2-495a-b2b3-553478fee15a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2ab73885-4165-44ef-97e7-6048f1c10c02"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2ae2aedf-4898-49de-a4f7-2ea012a22a2e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2b5ac29d-e5e5-4086-9558-2a00cc383e80"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2cc399a4-f8cd-44da-95a6-3afa2b9afca9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2cd03023-be5d-4352-ab43-463a68195461"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2cf24ff3-c105-47a0-8b6c-e29298593b0a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2e691345-8a4c-45b5-a9c0-cead4d1be9f3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2f6cb7dc-1481-4c69-8859-8f1c9f767301"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3094e40a-75c0-4368-9e59-64bd43130f44"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("324c0607-18b9-4ef7-888b-29836d397a99"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("32942bdd-2c15-4692-81eb-36b14a4ae858"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("33ca6a14-0572-4a5f-9b5f-e65f6c705517"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("34690773-cadf-49ba-bfae-7361ced8e6fb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("349f5e1b-ddfd-4213-bc46-da94868163de"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("34febaa9-4c0c-4340-9760-c7baaa8e76d3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("36740839-56d7-495e-af34-6e29021d9c56"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("36e0e073-f0b3-4a73-95ed-1930247f5341"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("381e1391-3537-42fc-aff4-80a5d08c8b0d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("38c8e07f-874d-4953-9e04-be4acf3aa080"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("39986092-ce12-429b-a548-d48546c5870d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3ac0c478-e595-43d0-8c9c-893a412b0ea6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3af36a66-b744-4935-8cb0-4541432b1e27"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3baf7cf0-19f5-4d9a-b381-fc762e0c519b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3db67c58-1ab9-4b36-adb1-a932a9217db9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3dc04d3e-80bc-475e-bb48-3fc0625fda3e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3dca10d5-9eea-4ca6-9373-48b742156146"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3e5ed709-8423-48c1-95bf-ed62eb08405d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3ed6ac73-31be-4239-ba1e-e6a5259623e4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("451343c3-8535-44d8-a182-ff60c62c4ca8"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4544781b-2ed1-4183-b59e-db0348b7a419"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("457017bb-9624-4e74-8e7b-b995a228c0bb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4584783e-6bcd-4632-85a2-26fd4922446b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("45c5de1d-a04e-4a1c-a2c2-9068c012020f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4af30448-1365-4e9f-b12a-bf6b1d0b2fa6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4c3dbe67-87ec-4edd-ad60-744fecfc738e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4d90ecee-368e-4259-99a4-55e37f038ba1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4eb345fd-3147-4a38-b4c6-658a01daa248"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4ebade0e-ad78-4d50-9998-9e7e60fcab15"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4f03f264-d3f7-44d1-ad73-04b2130732a2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("53af3302-65c5-4857-a00c-41c960524ac2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("54b327d0-e68d-43f5-b195-a0d214094803"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("54f02fc3-f5b2-419e-85a1-71459e98e7e0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("58d513d4-0e65-4f16-a37b-71d581b7da80"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("58fd90ea-c134-4eec-b44b-e50989508d70"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("59a51223-965c-4f1f-8474-74529cbfc82d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5a509bc4-d937-41a1-80ca-0b1ac3815700"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5cbe7c76-e173-4d5a-ae66-258650263216"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5d5a2ca1-381a-4df9-92ab-d654e0c11142"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5df1f9f9-ac06-4ccc-a84c-65c8a25acea2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("604c712f-7d61-4702-9c3f-9f781164d08a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("609436ef-887e-4c9c-bf23-1dd4f4317d65"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("60f0810e-6f62-433b-bc2f-98dae4420386"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6361a19b-3a8f-4c15-978e-ead54d1bcc74"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("648db3a3-2c09-471f-86fa-2f574078717d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("66a9d593-54f3-4b8e-85bb-9afdf7c89a42"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("685ca5ac-300b-40da-8099-0cb3adfc0546"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("68c58ab4-5321-45d8-8d54-366463944040"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6a79b0ac-0113-4fec-a1fc-3d7741e672a6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6c3fba0a-276c-48a6-ac24-364d9c2d972e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6c9d64b0-d0a3-42e1-ba24-6941f5a6988b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6ce94428-6e69-4e1c-b83a-1ae1568bd274"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6f31b4d0-ada0-4b99-89de-cefc8f44efab"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("716ccaec-7eb7-4f67-822e-d0a321704893"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7234a7fe-eed3-40bf-b17f-3174f5889e0b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("724ee8e0-9542-461a-aa6d-c6e64e01b341"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("74116904-b141-4bc3-ba4a-0c82bbafb638"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("743e7328-c55e-41b9-a029-50c1cc5b272b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("746f9a5f-daca-431e-9ae6-ba7ea68845d1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("751c2ffc-5cef-417d-8bfc-7073b1f56374"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("774ec694-6ce4-4046-8c30-aaa0eae7d078"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7884c654-f095-4755-9a33-218cec411634"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7cc57d37-e3f8-4393-abee-8a8aad3f60f6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7d8ad7d0-a6f5-4ee0-8be2-7c02cc45cf77"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7dc9e6d8-848a-43ac-b679-365dbb299c6b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7dfc0a07-499a-4c38-9594-a911bb87cd3a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7e9804de-11a6-48cb-90e0-af73b5bb6f1d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7f65a899-9327-41db-a67f-6a2d4c69a04b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7f6d3908-b870-43f5-947b-ab8e4e2f5d44"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8247a1b5-862d-438b-8313-7b93cb97a183"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("84754ee3-36e8-4cae-9722-9713c3ebc5eb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("84c9bc35-4986-4e8e-a360-e697254e7fbd"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("855d5632-73f8-4482-afdb-e8a1f4183af2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("856907be-47e5-4ce6-987b-e4362118561b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("856ad28b-1156-4b93-80aa-7967e73fc6bf"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("861d292b-a1a8-4ccf-93f6-cdbf55f6f88e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8842fa97-1e8f-4360-a0bd-5e46ae166b82"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8c718945-c982-48ec-908b-b91d6ba8cac3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8d2d052c-16a1-431f-ae57-7d5e86c054a7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8d9ee36e-f606-4c38-a761-d885e010ad0b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8f44aef1-99a1-4a83-8075-04b7671f6ce7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9459ca3d-ef12-4457-a5b5-298c1a1fc6e3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("949fd6ac-95f7-4051-a58f-09206320d959"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("94f9b0a7-9a23-4426-a74e-267e6704354f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("985bebeb-fc4e-4da7-8521-02e2e651dfe4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9a054962-ebc1-45de-ac41-fcf843ef6e6e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9a4a48e7-a52c-457e-9f9e-189c6d0beaea"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9a79388b-485e-412c-9571-d873ac84a76c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9b49b257-defe-4ae1-87a9-21407fce7b99"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9ce93468-6a4a-450e-acfa-b498b5e7e2f1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9da70ee7-3094-48eb-84a3-f84cabd66c25"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9dfcef3b-2d7e-4281-bfe4-a1ecff5e8e34"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a091cf6a-d4a2-4d29-ab42-c241aa8cedc0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a1007d6c-2490-4605-be35-1f9e5e03483f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a2678c33-c13a-450f-9160-59ac2aeabbc1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a36eabdd-5c2e-4f77-b41a-82d75085ed0b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a5b92710-2215-4af6-9f84-c9f4e8662a05"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a5d4d984-47c7-4b64-8844-17bea46d0414"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a74c8a27-7f4b-49b5-b030-f98fb4285c14"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a84649c2-0089-4a14-a68e-ff4616a474e2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("af475942-8f5b-4cd3-b894-4a2d3cbb0189"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("af8ea610-f52f-4cd4-84ae-be5615e25675"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b5541853-a456-47ff-bba1-f51c43dc3517"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b55692ba-04bb-4698-a68b-8915c946bc3a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b6eca23c-83c0-4ec5-9f69-4d71d295c366"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b8428655-21b8-4f93-a26c-72ddaf8b0a7f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ba4ecd85-c022-4a18-8938-1811b2bad598"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("bb0c1513-429a-4ae5-9801-6af103e79f08"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("bb69e608-f96f-4193-97c9-e29b3260d18d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("bbbfbecb-2449-4487-a5a7-d923b3c630f5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("bbd084f7-027a-4e4b-ba12-f56b57d1ab39"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("bcaa6977-6b2c-460c-9533-1f64a4ac7b65"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("be57fbb0-6040-4fad-9e8a-d3bbd323b444"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("beebd9ee-6e89-4b35-82f5-3b5cdcd7edc7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("bf0b0fa2-3222-4868-ba8e-01b02f8078d5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("bf41e6fa-422d-4e37-8056-41339bccd9ab"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c1cb340e-940a-445b-91b5-db4945e97175"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c2925411-3c23-49f7-ad44-755746968342"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c38e5b19-884b-4f7b-a1e0-ed84aea5e632"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c490c172-08aa-4c09-9af1-79c034a795ee"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c4e1bf40-5ae0-478b-b14b-375e936e8c54"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c5cf7aa1-1d77-468c-834f-cb24ca74841c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c60f1028-8a01-459a-92a5-e1df0a77c1e2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c66a0aee-7ef2-4292-a0e2-a7e53d893289"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c8151319-a683-4ef5-b6d8-760a5abc7a51"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("caaa4058-a4cf-412c-b39e-5eac76820711"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("cb15132e-0b65-4b7b-ab30-708c1d6b1199"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("cd555634-f5bb-4fdd-b4b0-77948ab841e1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ce647eeb-fe8d-426c-9087-f5a74907234b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d022377f-7bbc-430d-a9c2-96d680b8ce65"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d0234c90-7b2d-4504-a382-08cdba21a3a0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d0f646f0-ef8e-4867-8444-41d47b753260"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d100dc61-620f-43a7-9b0d-d353e371a4b6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d14c2dcb-6149-4ac8-b748-b56d8b2ddfb9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d27dd49b-587c-4e45-a542-9daae9138495"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d3eba990-fc0b-4ec6-a62c-48983921d15a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d41c546c-a285-44af-8a72-f9c02547d7a3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d48064d2-0bc8-4a04-af4c-213e6aa59198"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d653c304-ff57-4fde-897f-af97a2122b73"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d65c53b8-9e14-4154-8e33-63691149fe46"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d66ee138-cc18-4b98-ba1d-776af31f4a7f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d7b55bfd-66ee-4a73-ab48-697b3f907e7e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d7e24a68-caf9-4182-bef4-bb8c8c568c82"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d8d870a2-322f-4bfc-bb5a-bd3a342093a9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d904bbf1-6227-464d-80ea-32efaac6531c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dd07b0ae-74cf-42e8-9ec8-4a8cf59de3f0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("de9a955b-f608-4301-8400-b653690d4ffe"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("de9f6bf1-a7bd-479c-89d2-c9b8c7b5862d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("df2adb65-dae8-4058-9226-ea91d510a0d4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("df41a64f-3aa3-495e-8621-c88dd6c08df4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("df5b9be4-145e-472c-a979-622c70081145"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e03f4a3a-9ad6-4ec6-a4a5-e82f6ec4d6e5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e0fe17a2-65e1-48cd-ae15-0cffc335c15f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e12df32d-2efd-442c-b869-32fc8f234589"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e25e0c06-2513-4a83-aa62-20935cc237f3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e3bc8b5f-abbe-452e-93eb-b2cb3bfea81f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e3cacad2-000f-465f-9fce-e7b98d7af0d1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e3f31d73-cf41-4fd8-9cc6-2169ab38c8ac"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e497586c-e713-4531-b682-eeb8e761bf59"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e69b3aba-a769-46b4-9822-c84f12cf85a5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e7825a4a-ab92-4582-9add-b688c7e8010c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e9e5a7c4-4bc7-49be-90c2-4f481aac7752"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ea198c3e-caa4-4dce-8ac7-175fec4473cf"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f2d834d9-e89a-4f0c-8abf-475f065e6579"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f2dae296-c003-4862-85e1-6c5613ea670e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f55e2dde-fcba-427d-86b9-12fa1447bad8"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f5756b70-5c0f-4685-ad06-82a4642d40a8"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f616456d-1103-4597-bd8a-c9fc7deec121"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f6cbc760-eae0-4d2f-93c8-3af35e19b804"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f9d66ac3-e9c0-4573-846f-a3890d69d3fb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fb74dcbd-4ce4-4ed2-8abb-d92ab657d41a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fbd0706f-d550-41ae-93b1-ae44456d7f53"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fe8094be-21c0-4cb2-bd4d-e07ff725249c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("feb620b1-5b6b-403f-b76d-1212cb19fb58"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ff57ee13-0a8b-4d77-a58e-b3b441f11fbd"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ffae7dd5-ef75-4ef5-a6c5-81784f92cc2e"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("0d9483cb-bbde-44af-ad7f-ca94a99399f5"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("26ba685a-9543-4d14-a848-77dc5e741761"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("2ade937e-231c-4fc6-b48b-31bf7773e8a3"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("45e822b7-335c-4b5a-be13-5d5d2d84c8a2"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("4ceb30ac-cac8-48cb-9d36-ce87376e8fcb"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("638442e6-29b8-458f-a9a9-414186565efc"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("90f54812-230e-4fbd-bbdd-7b545456a768"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("a267affa-2fc7-4085-a6aa-daa4f531ece0"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("b294185e-360f-4169-b7f0-726a84401812"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("c0a0b90d-1ea8-47a5-9f90-6de9aafbf1d0"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("dc4de66d-1ebf-43df-8d51-e531699fdc63"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("e5774f97-bacd-419a-852c-7f393f0984a9"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("5470d9fb-c969-45aa-81f2-5d4f9d63e609"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("b2a730a9-f9ec-49ef-ac19-7277a31cb9ab"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("b54fddef-a30d-4afd-b526-d47091aa69d7"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("ba78b0b6-b632-403b-b96f-46bc5d025846"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0847de09-33a4-4644-b13e-9fd6828a336b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0bfd7ea8-598f-42c6-ba49-648d3af2bafc"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1046e8bc-6241-438a-8b67-8983d471518b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1301b30f-4ae0-4574-ae5e-69a94a9b0de1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("136de81c-3aa6-4d71-aa2a-16ecc2e0712a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("13863b19-b072-44b6-b81c-11fb40f2f9dd"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("13ce5ad0-ba50-431f-ac65-1649d7637ab5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("18b49b52-c923-454d-bbc1-a128ee7ac366"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1e81b69a-3a03-4010-a107-48470d782349"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("22f1365e-3b8e-4e85-bfaf-f7a3f337d209"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2a6900de-18c4-4b58-92d1-8b6225d48e31"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3113e94f-ee52-498c-ac67-d23d27c5b4d6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("31a33dcf-ec3a-413d-a512-fe7bcd2c931c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("45aa65b3-90aa-4859-9a44-e9f1ba1d98af"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4cb0acda-d622-48b7-a595-adfda0b96fe5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("51eea30e-56e0-45cb-a2f2-37511fc4bbf7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5a8836cb-2d8e-411e-8067-7cd7d12fd456"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5ada11a7-7360-49fd-a2fe-912e2299c7e5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5b1a203b-532b-411c-bb1d-923b55031174"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5c6d3cbb-e468-4d87-a7b2-b3ae5cf9fbc7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5c9a830e-f957-4097-bb69-9e80a36079a8"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5fea5c90-4498-4ca4-a137-04c6b11874c6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("64a4326a-5de2-4c3a-8e60-02a95a3c64f4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6c991be1-bf2f-43d8-baa8-7f912e170008"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6ed056a8-c7a6-4c8d-93ea-91b5e910f0ac"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("74de7c7f-b9b3-4cac-beb0-4184deb56848"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7e3dcfd7-14bb-435a-bb0a-e32915ed24bd"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("812be9b3-ba39-4f34-b8aa-046946229f70"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("86cc5bdf-179f-40ab-8d62-5d96bca006d6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("871ea182-d926-4fbc-886c-fa9c4c436185"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("879df8eb-1f86-482a-afdd-6f69d245b483"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("899e9e38-13c4-41cb-af9d-9dfc98b8e6e8"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8b2363fa-95cb-453a-a645-b5050a1e85f5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9235ae68-04bf-487a-aff1-95f194145bb0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("92982ead-15d8-42b5-9a3d-87a1b9820c5a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9dbdd344-17b6-4a50-b224-724be130617d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9f3c96ca-e989-482c-aead-7809c27fe13c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a0e9db37-e0d1-4517-8741-fcafddb6460e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a1f2ed13-2b11-4146-910c-ce009f3738fc"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a33b884c-b01b-4551-9301-aa54b43d48d0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a73d798f-1d41-4bba-9e50-7efdb41970bf"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("aad3c8f1-04c5-4013-9297-125444ca5b90"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b123d6f5-d4b4-4805-a6fb-db7cf909eaa0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("bed1b3ed-8c1f-4fe6-ae3b-290b7ee4c964"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("bf107f88-a6f0-4174-9252-07a39bbd8e14"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c479d115-b203-4237-a65a-9834645f1611"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("cec4d986-f729-49d3-a809-166fec84def3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("daea1511-4213-4dfd-849d-d7fc846b5f0e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e31361fa-f014-4c74-b53a-b88710735960"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e7672caa-511d-49df-b856-1b9085126fd6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ec00feff-48ba-41c6-a703-d6cf77fab4fd"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("eeea44e4-08d8-4332-bc97-3ec784ffc508"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f0c344bf-4e30-4083-97a9-8a4c963cb530"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f0f3a259-c3fd-439a-b925-5124a0c7f2bd"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f86f21d4-75ed-428e-a460-d8c23ad05e86"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fc9ca369-df9c-49bc-9409-8fc7b5587397"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("083fbf61-4b06-4e58-892f-48b325563e03"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("13d5960c-2a43-447a-a628-760246cdf4fe"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("1414296b-7d93-4f32-a161-65bfeb0b1028"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("1a44432c-d38b-4fae-a8ac-95802c1daf4b"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("23c04279-a46d-4ac7-8bb0-40579e43b754"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("2637c1da-cd98-4225-a084-0fdc7b3aba4e"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("27606fc6-b45e-4c4d-a211-5b26eb59fee3"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("327ae4f1-9ecd-49dc-a92e-bd71b4ac9694"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("460af3c6-b087-4c43-b612-3b540573d95c"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("492edf8c-f9d9-460d-8dbe-5c7c5425bf98"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("4b229974-132b-45c1-9e04-b2ad3d20a31b"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("680c3314-0ac4-4275-8170-b4a1b73d0b86"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("71a99dac-b986-4d92-84e1-715ae1c4aa54"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("8c96b12b-5fe3-4b15-a271-e26c51da3b02"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("8dac575b-0298-455c-a62d-5e04badebc57"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("95a7b872-00f3-4149-adf9-ee0f17d7e874"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("99cb0e16-1d71-436f-b717-8508e3127f73"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("9beeab16-2874-4812-8ced-eac882ab9929"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("9c94475f-005a-4a1b-bb78-8d0e46aec6d6"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("9fdb912b-fac9-49be-8f8b-17172e9a2c85"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("a213c566-a91a-4cbf-8c01-871c27390d35"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("a5f0726a-1f75-4995-a2cb-dbfc4ceeee52"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("ae080daf-0a36-435a-995d-ea04bd417270"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("b3b93ea3-ecc5-49fb-a7cf-54ff1f32ea4f"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("b645ef34-dc6f-4c6f-be58-6f65b13871f1"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("be71df7d-c2c4-4d8c-a60b-fb67e796c3c9"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("c43f4f29-0a49-4855-80c8-ae096714da79"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("cf171282-137c-41f4-b732-1cc9e47886b7"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("d4c3849f-d45c-4898-b660-c3598d3def6e"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("db54c1de-a14f-45a2-8541-044d5b94875f"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("ddffdd09-9671-43df-bc8e-d0ae682edfa8"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("fa93c83f-a4fc-4c13-81bf-117dd6a5de50"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7a47e970-7677-4cc1-9a0d-9d8992d1c777"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fdd5335d-8fa5-4d10-8435-d4aec7b6245a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("86c2222f-d07d-4540-a667-fbb663aac40b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a1d5017b-0d2c-4c91-8a6e-6ccebe987442"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("1e7f2ca5-c111-471e-9dbb-101a55f34d01"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("89334edd-5b93-454f-8a68-a8d207943048"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("b80a4b22-8bb7-4d92-818f-b43bbe8bc480"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("c1962484-4bea-45cd-990e-4fe39ec4fd45"));

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId" },
                values: new object[] { new Guid("fcd81c78-9863-4dc0-ad4d-8148fe7cfc60"), new Guid("d5fc13ff-3cbd-4a0c-b400-6badf1d54263") });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId" },
                values: new object[] { new Guid("2ba8fe74-4bf6-4a35-8922-96754001d7df"), new Guid("3a38028e-8886-49e7-ab6a-f613ec71c67d") });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId" },
                values: new object[] { new Guid("2e911361-796a-4742-a451-07c0852c7db9"), new Guid("8e932dbf-d4b6-43f5-aff3-af6684655e79") });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId" },
                values: new object[] { new Guid("e2063825-51ae-4d21-bb99-542127c58054"), new Guid("44e01935-6329-4a00-a0ed-bbea8fcdfe27") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("5bca3bb0-6e97-40f4-b283-6ea631f446b3"), "TrainingCreated", new Guid("fcd81c78-9863-4dc0-ad4d-8148fe7cfc60") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("c55ed659-212f-4f3f-8b11-3919155cbd58"), "NoteAdded", new Guid("fcd81c78-9863-4dc0-ad4d-8148fe7cfc60") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("2e82a743-c1b0-4dd1-a124-81608a6aa97e"), "MediaAdded", new Guid("fcd81c78-9863-4dc0-ad4d-8148fe7cfc60") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("083616fa-326c-4152-8724-72d4fea99064"), "TrainingCreated", new Guid("2ba8fe74-4bf6-4a35-8922-96754001d7df") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("adf177b0-9da9-473d-921f-bf71fbfeae20"), "NoteAdded", new Guid("2ba8fe74-4bf6-4a35-8922-96754001d7df") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("ff83dd0d-6fe5-43d3-99b8-f61324cdb703"), "MediaAdded", new Guid("2ba8fe74-4bf6-4a35-8922-96754001d7df") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("2603c074-afcc-46ec-b028-a5c65b8cc813"), "TrainingCreated", new Guid("2e911361-796a-4742-a451-07c0852c7db9") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("60f408df-5afd-41f0-9aa4-765f95c8e57b"), "NoteAdded", new Guid("2e911361-796a-4742-a451-07c0852c7db9") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("c6ff475e-a802-440f-bd99-98bec7edc32d"), "MediaAdded", new Guid("2e911361-796a-4742-a451-07c0852c7db9") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("8d83eb09-954f-4748-b775-5a11b767f26f"), "TrainingCreated", new Guid("e2063825-51ae-4d21-bb99-542127c58054") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("3315f2a6-19b6-4af0-89c2-138cb638bc51"), "NoteAdded", new Guid("e2063825-51ae-4d21-bb99-542127c58054") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("a884025c-4bc8-4c5f-b056-1be64de06e15"), "MediaAdded", new Guid("e2063825-51ae-4d21-bb99-542127c58054") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[] { new Guid("d5fc13ff-3cbd-4a0c-b400-6badf1d54263"), "Admin", "https://ui-avatars.com/api/?name=Admin+&rounded=True&background=314B79&color=ffffff&", new DateTime(2019, 11, 21, 23, 36, 23, 123, DateTimeKind.Utc).AddTicks(3783), "cus_FLi7gZv8w0j0GB", "admin@trainingcompanion.com", "Admin", "", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", new Guid("fcd81c78-9863-4dc0-ad4d-8148fe7cfc60"), "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[] { new Guid("8e932dbf-d4b6-43f5-aff3-af6684655e79"), "Coach", "https://ui-avatars.com/api/?name=Coach+&rounded=True&background=BBFFEF&color=ffffff&", new DateTime(2019, 11, 21, 23, 36, 23, 124, DateTimeKind.Utc).AddTicks(1060), "cus_FHk5RepADdfm5H", "coach@trainingcompanion.com", "Coach", "", "e0f167bc84b881bc06f6884fb48e02f41dfc5579e25489db6c6bde238e4aed15", new Guid("2e911361-796a-4742-a451-07c0852c7db9"), "coach" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[] { new Guid("44e01935-6329-4a00-a0ed-bbea8fcdfe27"), "SoloAthlete", "https://ui-avatars.com/api/?name=Solo+Athlete&rounded=True&background=8B01DE&color=ffffff&", new DateTime(2019, 11, 21, 23, 36, 23, 123, DateTimeKind.Utc).AddTicks(8957), null, "solo.athlete@trainingcompanion.com", "Solo", "Athlete", "304301ea5935cd1d38e55206e09eebcfe95fcb56f96ddf0ef2d8557a295728c8", new Guid("e2063825-51ae-4d21-bb99-542127c58054"), "soloathlete" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("99f4af86-22d9-42c4-97a7-619c76bf8ba6"), new Guid("d5fc13ff-3cbd-4a0c-b400-6badf1d54263"), "Squat - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("5e42f2ef-4d54-4689-8e9a-d6467940c64b"), new Guid("d5fc13ff-3cbd-4a0c-b400-6badf1d54263"), "Bench press - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("676626d7-2eb4-480b-a126-d87a08f3a296"), new Guid("d5fc13ff-3cbd-4a0c-b400-6badf1d54263"), "Deadlift - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("e340b2ef-558f-4aff-ac1e-653c8ade0215"), new Guid("44e01935-6329-4a00-a0ed-bbea8fcdfe27"), "Squat - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("560ac9e1-67ad-4868-8167-6c95798d0984"), new Guid("8e932dbf-d4b6-43f5-aff3-af6684655e79"), "Deadlift - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("bc76842c-16c2-4a2c-8501-4c373c93d798"), new Guid("8e932dbf-d4b6-43f5-aff3-af6684655e79"), "Bench press - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("b9f27592-73d7-4092-b23b-acb9a34e2cd5"), new Guid("8e932dbf-d4b6-43f5-aff3-af6684655e79"), "Squat - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("5724ea9e-0908-4077-a551-2b46d6503272"), new Guid("44e01935-6329-4a00-a0ed-bbea8fcdfe27"), "Bench press - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("0ab7c0e4-3df8-48ce-b1fb-6eda07bfcbc1"), new Guid("44e01935-6329-4a00-a0ed-bbea8fcdfe27"), "Deadlift - competition" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("761ad50c-3dcd-4dcf-b499-7a340cf99018"), new Guid("8e932dbf-d4b6-43f5-aff3-af6684655e79"), 7, "Tempo" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("4a31bd56-56f6-42b9-8336-615d7a4028a9"), new Guid("8e932dbf-d4b6-43f5-aff3-af6684655e79"), 8, "Load accommodation" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("6074c44a-efb0-47e0-81ba-ff7a2e4aced4"), new Guid("44e01935-6329-4a00-a0ed-bbea8fcdfe27"), 0, "Category" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("fefe5c38-f73a-4196-818b-810daaa7f4aa"), new Guid("44e01935-6329-4a00-a0ed-bbea8fcdfe27"), 1, "Bar type" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("6b4a4884-68f0-4d20-b3dc-fe0f315a6ff7"), new Guid("44e01935-6329-4a00-a0ed-bbea8fcdfe27"), 2, "Bar position" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("bfd7adaa-71aa-4ea5-8ddd-a716a8407fa3"), new Guid("44e01935-6329-4a00-a0ed-bbea8fcdfe27"), 3, "Equipment" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("6a75626c-4f42-4f4d-aba8-f9c50976a9e1"), new Guid("44e01935-6329-4a00-a0ed-bbea8fcdfe27"), 4, "Grip" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("4fafb0d7-5515-4e40-b7ff-1c20963b9e80"), new Guid("44e01935-6329-4a00-a0ed-bbea8fcdfe27"), 5, "Range of motion" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("ed21cfda-2730-45e2-9f7c-dd483cb3d25c"), new Guid("44e01935-6329-4a00-a0ed-bbea8fcdfe27"), 6, "Stance" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("dbc9cbef-ea4e-4b96-9229-94326fca9a5e"), new Guid("8e932dbf-d4b6-43f5-aff3-af6684655e79"), 6, "Stance" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("53c59ca4-7fe5-454d-abc8-5918c50e5bd5"), new Guid("8e932dbf-d4b6-43f5-aff3-af6684655e79"), 5, "Range of motion" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("28baa537-fdb5-4769-b6c4-58ed09d0483b"), new Guid("8e932dbf-d4b6-43f5-aff3-af6684655e79"), 3, "Equipment" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("9a92b988-746c-4920-b05e-78e9eed61bfc"), new Guid("44e01935-6329-4a00-a0ed-bbea8fcdfe27"), 7, "Tempo" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("63c76e17-8fd3-4a42-8da6-51c90b72d629"), new Guid("8e932dbf-d4b6-43f5-aff3-af6684655e79"), 2, "Bar position" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("988566a2-ff57-433c-bdfa-606759b6a1fa"), new Guid("8e932dbf-d4b6-43f5-aff3-af6684655e79"), 1, "Bar type" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("5b14d294-dd3d-4b1e-bbfa-7ad247ffc5fc"), new Guid("8e932dbf-d4b6-43f5-aff3-af6684655e79"), 0, "Category" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("52c75e8a-11e3-43f0-a183-a6cad6fb9447"), new Guid("d5fc13ff-3cbd-4a0c-b400-6badf1d54263"), 8, "Load accommodation" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("5c83ac85-e0eb-4641-a091-0a9588c6c6b7"), new Guid("d5fc13ff-3cbd-4a0c-b400-6badf1d54263"), 7, "Tempo" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("e0787012-fc25-4fc7-95fb-74d8760e2061"), new Guid("d5fc13ff-3cbd-4a0c-b400-6badf1d54263"), 6, "Stance" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("0ac78fcb-682e-4e70-975b-b428eab1b50d"), new Guid("d5fc13ff-3cbd-4a0c-b400-6badf1d54263"), 5, "Range of motion" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("84e2ce26-b23b-40e8-98cd-ba1ffa2393cc"), new Guid("d5fc13ff-3cbd-4a0c-b400-6badf1d54263"), 4, "Grip" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("5299cb43-fb99-4d12-b23e-4ecc7d2e1da7"), new Guid("d5fc13ff-3cbd-4a0c-b400-6badf1d54263"), 3, "Equipment" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("81854fd5-c210-4661-9bb4-7430c4232c09"), new Guid("d5fc13ff-3cbd-4a0c-b400-6badf1d54263"), 2, "Bar position" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("f1530d50-bfb6-478b-b5c8-0ea238fcccd5"), new Guid("d5fc13ff-3cbd-4a0c-b400-6badf1d54263"), 1, "Bar type" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("f313499e-588f-44b3-ba24-a1cae87d9ff1"), new Guid("d5fc13ff-3cbd-4a0c-b400-6badf1d54263"), 0, "Category" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("b563e880-5079-488e-8020-6b12038c2aa3"), new Guid("8e932dbf-d4b6-43f5-aff3-af6684655e79"), 4, "Grip" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("35c1b4f6-bb14-4f78-b884-12f92d953773"), new Guid("44e01935-6329-4a00-a0ed-bbea8fcdfe27"), 8, "Load accommodation" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "UserSettingId", "Username", "CoachId" },
                values: new object[] { new Guid("3a38028e-8886-49e7-ab6a-f613ec71c67d"), "Athlete", "https://ui-avatars.com/api/?name=Athlete+&rounded=True&background=C197D5&color=ffffff&", new DateTime(2019, 11, 21, 23, 36, 23, 123, DateTimeKind.Utc).AddTicks(7951), null, "athlete@trainingcompanion.com", "Athlete", "", "23a1f74bc589fe525387f8d2c40f1e552a564fe5de00af935bb7a0592fc976c6", new Guid("2ba8fe74-4bf6-4a35-8922-96754001d7df"), "athlete", new Guid("8e932dbf-d4b6-43f5-aff3-af6684655e79") });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("83d49648-7271-40a7-b6eb-34a2756b0383"), new Guid("3a38028e-8886-49e7-ab6a-f613ec71c67d"), "Bench press - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("94abc1b7-a5f2-4679-973b-0cce6acef187"), new Guid("3a38028e-8886-49e7-ab6a-f613ec71c67d"), "Deadlift - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("1b4de829-24a5-4dfb-871e-0d158fd13c39"), new Guid("3a38028e-8886-49e7-ab6a-f613ec71c67d"), "Squat - competition" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("15409f18-cf11-46b6-a4d1-93d20df98aa2"), new Guid("3a38028e-8886-49e7-ab6a-f613ec71c67d"), 0, "Category" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("5dff48b3-13a5-4fc2-8ec3-e77e1b916413"), new Guid("3a38028e-8886-49e7-ab6a-f613ec71c67d"), 1, "Bar type" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("84fe3332-8aa4-4f4f-8e2c-fb8d7b89c390"), new Guid("3a38028e-8886-49e7-ab6a-f613ec71c67d"), 2, "Bar position" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("7671b037-bcbe-4f03-9327-0558a45cac97"), new Guid("3a38028e-8886-49e7-ab6a-f613ec71c67d"), 3, "Equipment" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("4c0956b3-412d-4323-9b95-02bbfa00406e"), new Guid("3a38028e-8886-49e7-ab6a-f613ec71c67d"), 4, "Grip" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("9ac2708b-377a-4f18-a67f-aa34a57700c2"), new Guid("3a38028e-8886-49e7-ab6a-f613ec71c67d"), 5, "Range of motion" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("04c64b79-bb52-4b4c-818d-0bd9ab0f3c2e"), new Guid("3a38028e-8886-49e7-ab6a-f613ec71c67d"), 6, "Stance" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("da613513-c07e-4d60-b598-7dc7bf446a85"), new Guid("3a38028e-8886-49e7-ab6a-f613ec71c67d"), 7, "Tempo" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("ab36a8f0-1579-4182-8632-eb405e52396b"), new Guid("3a38028e-8886-49e7-ab6a-f613ec71c67d"), 8, "Load accommodation" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4fc79f2e-888a-4f4f-86bd-48a269d9128a"), 0, new Guid("f313499e-588f-44b3-ba24-a1cae87d9ff1"), "Knee dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e185926f-c9b1-4da2-906d-5d4a87ff36d9"), 0, new Guid("6074c44a-efb0-47e0-81ba-ff7a2e4aced4"), "Knee dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3d44594f-a842-4c7b-a126-e155c73ebd4d"), 2, new Guid("6074c44a-efb0-47e0-81ba-ff7a2e4aced4"), "Horizontal push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d6241117-115f-44e8-80a5-7e086eaafc44"), 3, new Guid("6074c44a-efb0-47e0-81ba-ff7a2e4aced4"), "Horizontal pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d64cb445-6272-4280-8bc7-c136d750cc3d"), 4, new Guid("6074c44a-efb0-47e0-81ba-ff7a2e4aced4"), "Vertical push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("72b6eb16-6183-42e0-b175-2349ac305d34"), 5, new Guid("6074c44a-efb0-47e0-81ba-ff7a2e4aced4"), "Vertical pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9d9b4e06-117a-42ab-be04-8c5d0d8086e6"), 6, new Guid("6074c44a-efb0-47e0-81ba-ff7a2e4aced4"), "Other" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0581fa51-e818-4a13-a562-6b0c44f2f472"), 0, new Guid("fefe5c38-f73a-4196-818b-810daaa7f4aa"), "Barbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fb3a1fbc-6ac1-46c4-a932-0de0fe5905a7"), 1, new Guid("fefe5c38-f73a-4196-818b-810daaa7f4aa"), "Dumbbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f2dcf584-68f1-4d07-87a0-956757798867"), 2, new Guid("fefe5c38-f73a-4196-818b-810daaa7f4aa"), "Saftey bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("07428cba-82b6-44a0-a08e-9252cd9e700e"), 3, new Guid("fefe5c38-f73a-4196-818b-810daaa7f4aa"), "Cambered bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d92c440f-2328-4deb-b112-c676780be9cd"), 4, new Guid("fefe5c38-f73a-4196-818b-810daaa7f4aa"), "Neutral-grip bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("255caacf-71fb-44a2-a0e4-6b972730f11c"), 1, new Guid("6074c44a-efb0-47e0-81ba-ff7a2e4aced4"), "Hip dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("dede716f-f41d-4ec7-bf49-e09e78fc2d07"), 6, new Guid("4a31bd56-56f6-42b9-8336-615d7a4028a9"), "Reverse strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ab536b95-e77d-4ef0-b59e-b66437e9e97a"), 5, new Guid("4a31bd56-56f6-42b9-8336-615d7a4028a9"), "Reverse average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("52aa6b65-5b9d-4d19-989e-3549a30c0ebe"), 4, new Guid("4a31bd56-56f6-42b9-8336-615d7a4028a9"), "Reverse light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f2b8c2bb-1b70-40ed-a8a4-4e868c79fc2b"), 11, new Guid("53c59ca4-7fe5-454d-abc8-5918c50e5bd5"), "Five board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("89376c1d-1be1-4a9f-b60b-03086c77ecfd"), 12, new Guid("53c59ca4-7fe5-454d-abc8-5918c50e5bd5"), "Towel - 8 cm " });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d2c08039-9ca0-4fe3-979a-97389232f138"), 0, new Guid("dbc9cbef-ea4e-4b96-9229-94326fca9a5e"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3898d8d1-4639-45e2-b5b7-3966532d65b6"), 1, new Guid("dbc9cbef-ea4e-4b96-9229-94326fca9a5e"), "Narrow" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("26052ea7-3bf3-460b-927b-db0b5ba41ec2"), 2, new Guid("dbc9cbef-ea4e-4b96-9229-94326fca9a5e"), "Wide" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4b22effa-7f08-4ce7-a1df-307765201381"), 3, new Guid("dbc9cbef-ea4e-4b96-9229-94326fca9a5e"), "Sumo" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("237bbd47-f7db-4e85-951a-99a52f02c501"), 4, new Guid("dbc9cbef-ea4e-4b96-9229-94326fca9a5e"), "Conventional" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("43544f20-0535-452e-95a1-6cc4a18dcde8"), 5, new Guid("dbc9cbef-ea4e-4b96-9229-94326fca9a5e"), "Stiff legged" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e999ad2c-2f50-4c24-a1b6-cff5eb4b7947"), 6, new Guid("dbc9cbef-ea4e-4b96-9229-94326fca9a5e"), "Feet up" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9917a54c-6e9c-4a69-b081-8314d6c861b4"), 0, new Guid("761ad50c-3dcd-4dcf-b499-7a340cf99018"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5df4db8f-b374-426f-953d-8f5413b92137"), 1, new Guid("761ad50c-3dcd-4dcf-b499-7a340cf99018"), "Touch and go" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e4e51a00-2e2d-4140-93e4-ab1403aab020"), 5, new Guid("fefe5c38-f73a-4196-818b-810daaa7f4aa"), "Trap bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("431ba3af-2990-4788-a461-d409a88e48e8"), 2, new Guid("761ad50c-3dcd-4dcf-b499-7a340cf99018"), "Pause - 2 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e67ef067-8b18-4a58-9ab0-1273ac917add"), 4, new Guid("761ad50c-3dcd-4dcf-b499-7a340cf99018"), "Pause - 5 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("86ae0cb5-9847-4e9d-b455-37cd6ce64432"), 5, new Guid("761ad50c-3dcd-4dcf-b499-7a340cf99018"), "Pause - 7 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("588cbc8c-4727-4338-9f79-33a696453810"), 6, new Guid("761ad50c-3dcd-4dcf-b499-7a340cf99018"), "Tempo - 600" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("72ef428b-654d-4f30-918f-8639d17a71e3"), 7, new Guid("761ad50c-3dcd-4dcf-b499-7a340cf99018"), "Tempo - 320" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("742c516d-3dc0-477b-ae02-eb8d7fffaf14"), 8, new Guid("761ad50c-3dcd-4dcf-b499-7a340cf99018"), "Tempo - 530" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a5de500c-9c75-4d5f-ace2-bcc927005339"), 9, new Guid("761ad50c-3dcd-4dcf-b499-7a340cf99018"), "Tempo - 303" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("822cd94b-efc8-4d42-9f08-e45a8c09ff08"), 10, new Guid("761ad50c-3dcd-4dcf-b499-7a340cf99018"), "Tempo - 003" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ebe480c0-4fd8-413a-80fd-f664e9052322"), 0, new Guid("4a31bd56-56f6-42b9-8336-615d7a4028a9"), "Light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b3dd3a36-c538-4f19-85dd-ebaf59a2163d"), 1, new Guid("4a31bd56-56f6-42b9-8336-615d7a4028a9"), "Average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3353a5f2-c90b-42a7-a190-964ed34625ac"), 2, new Guid("4a31bd56-56f6-42b9-8336-615d7a4028a9"), "Strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2af89b55-a72c-43a0-a8cc-14dbde178ea0"), 3, new Guid("4a31bd56-56f6-42b9-8336-615d7a4028a9"), "Chains" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("be47738a-43f3-43f5-8b9d-dd220dea79a7"), 3, new Guid("761ad50c-3dcd-4dcf-b499-7a340cf99018"), "Pause - 3 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2730e96f-2377-4e20-b784-b3b016c87877"), 6, new Guid("fefe5c38-f73a-4196-818b-810daaa7f4aa"), "Buffalo bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6f9ff983-a115-49b3-be0e-f89eef194bb5"), 7, new Guid("fefe5c38-f73a-4196-818b-810daaa7f4aa"), "Machine" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("af55b6c7-02db-4bb1-993c-5240f9e5f6b5"), 0, new Guid("6b4a4884-68f0-4d20-b3dc-fe0f315a6ff7"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b5fe06ee-4317-462b-85c8-c43d3caf6335"), 12, new Guid("4fafb0d7-5515-4e40-b7ff-1c20963b9e80"), "Towel - 8 cm " });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("241fbd0e-40e1-4b94-b4c8-89f3a2acd326"), 0, new Guid("ed21cfda-2730-45e2-9f7c-dd483cb3d25c"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e5aa22fa-7132-4891-a091-ac8fc74580da"), 1, new Guid("ed21cfda-2730-45e2-9f7c-dd483cb3d25c"), "Narrow" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5a53bffa-03b0-4907-b7dc-b84a1a280f33"), 2, new Guid("ed21cfda-2730-45e2-9f7c-dd483cb3d25c"), "Wide" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d47a77bb-59c7-486e-ad34-6ce1c3748a48"), 3, new Guid("ed21cfda-2730-45e2-9f7c-dd483cb3d25c"), "Sumo" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b65b54d7-7ab4-4d5e-b735-b187e2bb4948"), 4, new Guid("ed21cfda-2730-45e2-9f7c-dd483cb3d25c"), "Conventional" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c0436899-d415-43cf-af7a-d8c94ca8cd4d"), 5, new Guid("ed21cfda-2730-45e2-9f7c-dd483cb3d25c"), "Stiff legged" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5c70f9ee-39c5-4814-9a0e-4d2cdc258716"), 6, new Guid("ed21cfda-2730-45e2-9f7c-dd483cb3d25c"), "Feet up" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("578047e5-3e0d-4237-bc3f-a3ed369f154c"), 0, new Guid("9a92b988-746c-4920-b05e-78e9eed61bfc"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d9ff1cd1-2325-46ed-a511-0b9265b351e6"), 1, new Guid("9a92b988-746c-4920-b05e-78e9eed61bfc"), "Touch and go" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3a320dd2-0da9-4433-a13a-d4f9796c9094"), 2, new Guid("9a92b988-746c-4920-b05e-78e9eed61bfc"), "Pause - 2 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("678b623a-0fcc-4587-88f7-9ec1c7f5ebbe"), 11, new Guid("4fafb0d7-5515-4e40-b7ff-1c20963b9e80"), "Five board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1e39435a-af64-464e-847e-c40f13b02be7"), 3, new Guid("9a92b988-746c-4920-b05e-78e9eed61bfc"), "Pause - 3 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3a9e6da1-27fa-4c4e-b8aa-e41df82f13d0"), 5, new Guid("9a92b988-746c-4920-b05e-78e9eed61bfc"), "Pause - 7 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d4e1a5a8-0773-4728-9174-95a8d0be75dc"), 6, new Guid("9a92b988-746c-4920-b05e-78e9eed61bfc"), "Tempo - 600" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("42cdabc4-7fe5-464e-a5a9-f77c657965b2"), 7, new Guid("9a92b988-746c-4920-b05e-78e9eed61bfc"), "Tempo - 320" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("81db70dd-28d3-4b13-b3a8-e9bf0ad06164"), 8, new Guid("9a92b988-746c-4920-b05e-78e9eed61bfc"), "Tempo - 530" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("835d04c3-55f1-48a3-9d08-238b154fadc5"), 9, new Guid("9a92b988-746c-4920-b05e-78e9eed61bfc"), "Tempo - 303" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c901cdc6-608d-44dd-a7b1-e408cf5e19b2"), 10, new Guid("9a92b988-746c-4920-b05e-78e9eed61bfc"), "Tempo - 003" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9b12b484-c272-4524-a9af-e55be2dbc403"), 0, new Guid("35c1b4f6-bb14-4f78-b884-12f92d953773"), "Light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("862ec6d5-442f-4d36-ab1b-edb5d0810e4e"), 1, new Guid("35c1b4f6-bb14-4f78-b884-12f92d953773"), "Average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8a02985d-25e5-44cc-aa67-5abc5c6b99ae"), 2, new Guid("35c1b4f6-bb14-4f78-b884-12f92d953773"), "Strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a6b9c185-e1ba-4cad-80db-0a2856a157f5"), 3, new Guid("35c1b4f6-bb14-4f78-b884-12f92d953773"), "Chains" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a58dba64-1c89-472a-98fd-e47ad93606d5"), 4, new Guid("35c1b4f6-bb14-4f78-b884-12f92d953773"), "Reverse light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("02e6fb99-6b05-4701-a9be-e971b6fbf307"), 4, new Guid("9a92b988-746c-4920-b05e-78e9eed61bfc"), "Pause - 5 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7d6d9f5d-dad3-482c-83d2-01781d5254bc"), 10, new Guid("53c59ca4-7fe5-454d-abc8-5918c50e5bd5"), "Four board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1508e305-b42f-463b-b618-cba97e811175"), 10, new Guid("4fafb0d7-5515-4e40-b7ff-1c20963b9e80"), "Four board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("92e54d0a-5c53-47ce-8ee8-e7a0665ef35f"), 8, new Guid("4fafb0d7-5515-4e40-b7ff-1c20963b9e80"), "Two board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3c4be06a-fa24-44d7-9864-dc0120f43e82"), 1, new Guid("6b4a4884-68f0-4d20-b3dc-fe0f315a6ff7"), "High bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2a1d0b21-39fd-46c8-8cd9-fd4e2c54f56d"), 2, new Guid("6b4a4884-68f0-4d20-b3dc-fe0f315a6ff7"), "Low bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c29b1e8b-70e0-4dfa-85cb-4c66a6092a8b"), 3, new Guid("6b4a4884-68f0-4d20-b3dc-fe0f315a6ff7"), "Front rack" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("96ef8e5a-31d6-4ff9-a1d5-9a72b22c7315"), 0, new Guid("bfd7adaa-71aa-4ea5-8ddd-a716a8407fa3"), "Belt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4ccc837e-5d73-4f2a-b772-38a32a0ec654"), 1, new Guid("bfd7adaa-71aa-4ea5-8ddd-a716a8407fa3"), "Knee sleeves" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("53d5e94e-7909-4746-a70d-9ee14d9e8338"), 2, new Guid("bfd7adaa-71aa-4ea5-8ddd-a716a8407fa3"), "Knee wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e6647cb2-8de2-475a-83b9-c62b3dbc1771"), 3, new Guid("bfd7adaa-71aa-4ea5-8ddd-a716a8407fa3"), "Slingshot" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("db7c846b-b88b-4198-bdba-ca531c7b6218"), 4, new Guid("bfd7adaa-71aa-4ea5-8ddd-a716a8407fa3"), "Breifs" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0b4c41f2-e4d9-4e25-adb9-1247f2776d31"), 5, new Guid("bfd7adaa-71aa-4ea5-8ddd-a716a8407fa3"), "Squat suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b4257e9c-8eff-4d2e-9bbd-e9fa6c648d92"), 6, new Guid("bfd7adaa-71aa-4ea5-8ddd-a716a8407fa3"), "Bench shirt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b89c8414-8045-407a-83fc-5fa38e79a033"), 7, new Guid("bfd7adaa-71aa-4ea5-8ddd-a716a8407fa3"), "Deadlift suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2621ebd2-03cc-4ece-b3ed-3ce5901bc2fe"), 9, new Guid("4fafb0d7-5515-4e40-b7ff-1c20963b9e80"), "Three board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4453850a-c98c-47c6-bb90-a23f05d74068"), 7, new Guid("bfd7adaa-71aa-4ea5-8ddd-a716a8407fa3"), "Wrist wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f7925e4b-07bf-483c-bcae-69dccb875a57"), 1, new Guid("6a75626c-4f42-4f4d-aba8-f9c50976a9e1"), "Reverse grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b4b40c51-2dfc-4d7c-8e3e-5a1835e660f8"), 2, new Guid("6a75626c-4f42-4f4d-aba8-f9c50976a9e1"), "Close grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fbafda9d-ba58-466a-8eaf-87dd25e06037"), 3, new Guid("6a75626c-4f42-4f4d-aba8-f9c50976a9e1"), "Wide grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1c70cb31-d36a-4d91-8335-565d7b8c3b89"), 0, new Guid("4fafb0d7-5515-4e40-b7ff-1c20963b9e80"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4fa04400-a691-42dd-b1da-1a919fc57e26"), 1, new Guid("4fafb0d7-5515-4e40-b7ff-1c20963b9e80"), "Box" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("da70e2cf-8a08-4b8d-aad0-3069ad37c99c"), 2, new Guid("4fafb0d7-5515-4e40-b7ff-1c20963b9e80"), "Towel" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9b0728c1-45b9-4213-ad1b-05964ddbcb75"), 3, new Guid("4fafb0d7-5515-4e40-b7ff-1c20963b9e80"), "Low pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("71b73f59-98a3-4a51-940b-5616d7ce7307"), 4, new Guid("4fafb0d7-5515-4e40-b7ff-1c20963b9e80"), "Middle pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d0da595c-992c-4b9f-9dde-ef9de2b887ca"), 5, new Guid("4fafb0d7-5515-4e40-b7ff-1c20963b9e80"), "High pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7df949c5-515e-432b-8bdb-e9e5662d9390"), 6, new Guid("4fafb0d7-5515-4e40-b7ff-1c20963b9e80"), "Two inch deficit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("87943431-5c41-4d3a-9ddb-27a2ef0437dc"), 7, new Guid("4fafb0d7-5515-4e40-b7ff-1c20963b9e80"), "Half board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("600f7a21-44fe-4baf-90d7-ed25c37f309c"), 0, new Guid("6a75626c-4f42-4f4d-aba8-f9c50976a9e1"), "Snatch grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("07fe13c9-8c21-4c3b-83c5-5ef305a347be"), 9, new Guid("53c59ca4-7fe5-454d-abc8-5918c50e5bd5"), "Three board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e6b4db96-60b2-47aa-8e4e-fbf791cd423f"), 8, new Guid("53c59ca4-7fe5-454d-abc8-5918c50e5bd5"), "Two board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d2c00d6e-ed25-40fd-9d5e-2bc81bb5cc5c"), 7, new Guid("53c59ca4-7fe5-454d-abc8-5918c50e5bd5"), "Half board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("22a119b9-7d2f-4523-8f3d-a8f9ccbb6875"), 1, new Guid("84e2ce26-b23b-40e8-98cd-ba1ffa2393cc"), "Reverse grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fcaef1b5-7716-4b0f-b575-4a79c7bf6197"), 2, new Guid("84e2ce26-b23b-40e8-98cd-ba1ffa2393cc"), "Close grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ce5184b3-9f69-4a99-84c3-119b2f5b55e0"), 3, new Guid("84e2ce26-b23b-40e8-98cd-ba1ffa2393cc"), "Wide grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7dd3668a-c7a5-4a3a-9891-770288e14912"), 0, new Guid("0ac78fcb-682e-4e70-975b-b428eab1b50d"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a02aee3c-ed66-44aa-ad42-50d5f03581ae"), 1, new Guid("0ac78fcb-682e-4e70-975b-b428eab1b50d"), "Box" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f2119d83-2b58-48ee-9bbf-9624debcdd63"), 2, new Guid("0ac78fcb-682e-4e70-975b-b428eab1b50d"), "Towel" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("78a2dcca-a2c0-4820-b2be-1464de9cb746"), 3, new Guid("0ac78fcb-682e-4e70-975b-b428eab1b50d"), "Low pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e934fd03-a7b4-4434-a998-889384a22ab1"), 4, new Guid("0ac78fcb-682e-4e70-975b-b428eab1b50d"), "Middle pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1ce1b1d1-1996-4537-adb4-840646a918a5"), 5, new Guid("0ac78fcb-682e-4e70-975b-b428eab1b50d"), "High pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e7032f77-aa5a-4c12-98f0-e9c01bb690ea"), 6, new Guid("0ac78fcb-682e-4e70-975b-b428eab1b50d"), "Two inch deficit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("87c44005-eb18-4666-8841-7e7a694cfdfb"), 7, new Guid("0ac78fcb-682e-4e70-975b-b428eab1b50d"), "Half board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e778519c-bb72-4fb6-bd32-65b05b688b6a"), 0, new Guid("84e2ce26-b23b-40e8-98cd-ba1ffa2393cc"), "Snatch grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ed7cca78-fc07-4ee3-a0c3-2cc74ca6f1b0"), 8, new Guid("0ac78fcb-682e-4e70-975b-b428eab1b50d"), "Two board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("283b7f46-61e5-406b-8229-324ea7cc82d2"), 10, new Guid("0ac78fcb-682e-4e70-975b-b428eab1b50d"), "Four board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2a10639d-2365-4f8d-bc53-4549cd4a1c7e"), 11, new Guid("0ac78fcb-682e-4e70-975b-b428eab1b50d"), "Five board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b6a836f6-9b95-4990-9b87-a1aac258874e"), 12, new Guid("0ac78fcb-682e-4e70-975b-b428eab1b50d"), "Towel - 8 cm " });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("96276c9d-8ea3-4a8e-9140-b912a87a002e"), 0, new Guid("e0787012-fc25-4fc7-95fb-74d8760e2061"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a924e6de-c8d0-4991-878d-552f3766dcc6"), 1, new Guid("e0787012-fc25-4fc7-95fb-74d8760e2061"), "Narrow" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4341face-a862-42d2-bf47-781d46dbe1de"), 2, new Guid("e0787012-fc25-4fc7-95fb-74d8760e2061"), "Wide" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d4c0d33c-8a72-47d4-aa72-e858ef3dce0c"), 3, new Guid("e0787012-fc25-4fc7-95fb-74d8760e2061"), "Sumo" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e68b539d-e0e4-414f-a078-779ff5aaf593"), 4, new Guid("e0787012-fc25-4fc7-95fb-74d8760e2061"), "Conventional" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("79aba85c-90e8-488d-8ff2-439cda37e675"), 5, new Guid("e0787012-fc25-4fc7-95fb-74d8760e2061"), "Stiff legged" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a9d04007-bbd2-49f5-a346-78a7903f5fb9"), 6, new Guid("e0787012-fc25-4fc7-95fb-74d8760e2061"), "Feet up" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e631ee84-ca3e-4bf6-93ee-2d98afefdadd"), 0, new Guid("5c83ac85-e0eb-4641-a091-0a9588c6c6b7"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9f328dd8-889c-4e5b-bcaa-4c7667a12b04"), 9, new Guid("0ac78fcb-682e-4e70-975b-b428eab1b50d"), "Three board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("dbc89496-36d5-4199-9aea-5c3b81bfa43e"), 1, new Guid("5c83ac85-e0eb-4641-a091-0a9588c6c6b7"), "Touch and go" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d39f9218-506f-4517-b9ec-41180f3aafd3"), 7, new Guid("5299cb43-fb99-4d12-b23e-4ecc7d2e1da7"), "Wrist wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("cd0db0e8-b416-4a83-a4ac-01e80abce93c"), 6, new Guid("5299cb43-fb99-4d12-b23e-4ecc7d2e1da7"), "Bench shirt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("132ded0b-6ab0-4378-91c3-9cbda3df0a79"), 1, new Guid("f313499e-588f-44b3-ba24-a1cae87d9ff1"), "Hip dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("53feccb3-ba48-4119-9aff-1d48fe51d930"), 2, new Guid("f313499e-588f-44b3-ba24-a1cae87d9ff1"), "Horizontal push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7e0f22c4-f658-4a88-a3cc-6f12c1c7ed9f"), 3, new Guid("f313499e-588f-44b3-ba24-a1cae87d9ff1"), "Horizontal pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7fe1b2dd-9d66-44d0-9ca1-81eb1677a760"), 4, new Guid("f313499e-588f-44b3-ba24-a1cae87d9ff1"), "Vertical push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c4686382-7560-4b03-8a77-fd96ccc7894e"), 5, new Guid("f313499e-588f-44b3-ba24-a1cae87d9ff1"), "Vertical pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e56aadc5-f0f4-46f9-9ee2-1504a54b921d"), 6, new Guid("f313499e-588f-44b3-ba24-a1cae87d9ff1"), "Other" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8f4591c1-f06a-4329-8aec-330a4fa2b390"), 0, new Guid("f1530d50-bfb6-478b-b5c8-0ea238fcccd5"), "Barbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a2c7f139-d1c7-409d-a2b2-eaddbfaddf8b"), 1, new Guid("f1530d50-bfb6-478b-b5c8-0ea238fcccd5"), "Dumbbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fb8c0f17-0014-45f2-8c16-826c1eff610d"), 2, new Guid("f1530d50-bfb6-478b-b5c8-0ea238fcccd5"), "Saftey bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("33f54a78-aa7b-4132-a222-e11298c7d8d7"), 3, new Guid("f1530d50-bfb6-478b-b5c8-0ea238fcccd5"), "Cambered bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f00619a1-4b97-4dfd-80a4-e80752d3b02f"), 4, new Guid("f1530d50-bfb6-478b-b5c8-0ea238fcccd5"), "Neutral-grip bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("326cd8f4-c47e-43c5-8f7b-109db5f3579e"), 7, new Guid("5299cb43-fb99-4d12-b23e-4ecc7d2e1da7"), "Deadlift suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("99a92139-5623-4ae6-b6c3-7b7a59aa3302"), 5, new Guid("f1530d50-bfb6-478b-b5c8-0ea238fcccd5"), "Trap bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("01294e49-0f57-4ed6-8132-9d230bba8325"), 7, new Guid("f1530d50-bfb6-478b-b5c8-0ea238fcccd5"), "Machine" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a737f75a-66be-4ec1-bd1e-5700accc9e99"), 0, new Guid("81854fd5-c210-4661-9bb4-7430c4232c09"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9bcd4ceb-e366-4f1a-ac01-65ac7f5dd2e7"), 1, new Guid("81854fd5-c210-4661-9bb4-7430c4232c09"), "High bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("32beeaeb-5350-4b48-96bf-9355cff7182f"), 2, new Guid("81854fd5-c210-4661-9bb4-7430c4232c09"), "Low bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("995b091c-84dd-4b62-9433-b44af2fa1dce"), 3, new Guid("81854fd5-c210-4661-9bb4-7430c4232c09"), "Front rack" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2cdc5f29-ee79-4874-9fe6-6c9b0160a67b"), 0, new Guid("5299cb43-fb99-4d12-b23e-4ecc7d2e1da7"), "Belt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("32d7e113-4bd5-4cf1-92f4-ca09e3992980"), 1, new Guid("5299cb43-fb99-4d12-b23e-4ecc7d2e1da7"), "Knee sleeves" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("28c94875-8b49-4e83-973a-cbd06dc03268"), 2, new Guid("5299cb43-fb99-4d12-b23e-4ecc7d2e1da7"), "Knee wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("12d89d4b-0ce4-44ea-9026-2b81fa72ab13"), 3, new Guid("5299cb43-fb99-4d12-b23e-4ecc7d2e1da7"), "Slingshot" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("be98ba37-711c-4443-b953-7ed454e22994"), 4, new Guid("5299cb43-fb99-4d12-b23e-4ecc7d2e1da7"), "Breifs" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("46ca4f74-69b3-448c-8ee9-ab8ad839d417"), 5, new Guid("5299cb43-fb99-4d12-b23e-4ecc7d2e1da7"), "Squat suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ac46aad0-807a-4ed6-8345-4e5569de01cc"), 6, new Guid("f1530d50-bfb6-478b-b5c8-0ea238fcccd5"), "Buffalo bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("45bb89ac-4111-4a60-b5a3-4c4d7bbffa10"), 5, new Guid("35c1b4f6-bb14-4f78-b884-12f92d953773"), "Reverse average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2bb4e1ba-d6bb-4f0f-8bd6-354254003a73"), 2, new Guid("5c83ac85-e0eb-4641-a091-0a9588c6c6b7"), "Pause - 2 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("33247a96-b69c-4d6b-a151-e2b98594cb22"), 4, new Guid("5c83ac85-e0eb-4641-a091-0a9588c6c6b7"), "Pause - 5 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("97ed71c8-3608-4be9-bbfc-4ac4dc709a27"), 0, new Guid("63c76e17-8fd3-4a42-8da6-51c90b72d629"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0f2a7e7a-6188-4478-8c6c-fe7cf1ee7e6b"), 1, new Guid("63c76e17-8fd3-4a42-8da6-51c90b72d629"), "High bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ecefcba0-7ad4-4bfc-bb78-11130336e8a0"), 2, new Guid("63c76e17-8fd3-4a42-8da6-51c90b72d629"), "Low bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("92aaed79-946f-4206-a626-e3f21a3981f2"), 3, new Guid("63c76e17-8fd3-4a42-8da6-51c90b72d629"), "Front rack" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9d9ed3ab-7369-42d2-9064-f2cfaa61a6e0"), 0, new Guid("28baa537-fdb5-4769-b6c4-58ed09d0483b"), "Belt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("dbdc410b-492c-48d6-9798-0646eef56f02"), 1, new Guid("28baa537-fdb5-4769-b6c4-58ed09d0483b"), "Knee sleeves" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bddfa270-3358-48eb-8d48-0d1b99ddd2d5"), 2, new Guid("28baa537-fdb5-4769-b6c4-58ed09d0483b"), "Knee wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("28a2e23d-361f-4873-8fcd-ebd7caf25037"), 3, new Guid("28baa537-fdb5-4769-b6c4-58ed09d0483b"), "Slingshot" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("555a2ff7-b1a2-4098-867a-cec5f7df4008"), 4, new Guid("28baa537-fdb5-4769-b6c4-58ed09d0483b"), "Breifs" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("40d7e8b5-7293-47bd-9af4-6afcf92f36e4"), 5, new Guid("28baa537-fdb5-4769-b6c4-58ed09d0483b"), "Squat suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("56ebf7b4-5831-48d8-8f44-a028d009e71c"), 6, new Guid("28baa537-fdb5-4769-b6c4-58ed09d0483b"), "Bench shirt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e89c85ef-0721-4549-91a2-686a6075b0c6"), 7, new Guid("988566a2-ff57-433c-bdfa-606759b6a1fa"), "Machine" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("aed3f5bc-2900-4a97-bf59-cecc47762d4b"), 7, new Guid("28baa537-fdb5-4769-b6c4-58ed09d0483b"), "Deadlift suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d4ae0f6b-e6b5-436a-b9c4-0ecfbe49dcbf"), 0, new Guid("b563e880-5079-488e-8020-6b12038c2aa3"), "Snatch grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a32a1eb4-8c43-474a-95ea-a411218b629e"), 1, new Guid("b563e880-5079-488e-8020-6b12038c2aa3"), "Reverse grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e87fc1b4-b220-485d-a805-5c32aa0226c4"), 2, new Guid("b563e880-5079-488e-8020-6b12038c2aa3"), "Close grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("762e634d-9ab0-40c9-92df-d9f2576ed97f"), 3, new Guid("b563e880-5079-488e-8020-6b12038c2aa3"), "Wide grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a5cf346c-0a98-416e-b40d-f2dfa864f81e"), 0, new Guid("53c59ca4-7fe5-454d-abc8-5918c50e5bd5"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7f36b186-52f7-416b-88f6-d9fd1070ef65"), 1, new Guid("53c59ca4-7fe5-454d-abc8-5918c50e5bd5"), "Box" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("cf19d18a-4624-4783-b313-7a0b9516388b"), 2, new Guid("53c59ca4-7fe5-454d-abc8-5918c50e5bd5"), "Towel" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("670805a7-50ce-40de-8a39-bcaf26576c69"), 3, new Guid("53c59ca4-7fe5-454d-abc8-5918c50e5bd5"), "Low pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2cfec3d2-57f6-430f-8715-17cad59a7aba"), 4, new Guid("53c59ca4-7fe5-454d-abc8-5918c50e5bd5"), "Middle pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6bd75938-c045-4bd2-a0b2-1ab2f5534282"), 5, new Guid("53c59ca4-7fe5-454d-abc8-5918c50e5bd5"), "High pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b12b0c1c-a214-4bc0-88a9-8ce74c171a4b"), 6, new Guid("53c59ca4-7fe5-454d-abc8-5918c50e5bd5"), "Two inch deficit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b0397bd9-eb17-45b0-bb08-f59d92813500"), 7, new Guid("28baa537-fdb5-4769-b6c4-58ed09d0483b"), "Wrist wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("44c40fd8-6973-4765-aa14-bc314290f95f"), 3, new Guid("5c83ac85-e0eb-4641-a091-0a9588c6c6b7"), "Pause - 3 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("842053b6-3ef5-4b4a-9093-7617a1a3877b"), 6, new Guid("988566a2-ff57-433c-bdfa-606759b6a1fa"), "Buffalo bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("768f3bec-e886-408d-867e-12c3a2a54f7c"), 4, new Guid("988566a2-ff57-433c-bdfa-606759b6a1fa"), "Neutral-grip bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5badd649-9804-4502-b017-5ef31e3eb36f"), 5, new Guid("5c83ac85-e0eb-4641-a091-0a9588c6c6b7"), "Pause - 7 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6e0a34ff-3047-4443-b802-d15a78980f8f"), 6, new Guid("5c83ac85-e0eb-4641-a091-0a9588c6c6b7"), "Tempo - 600" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("85abd5b1-e658-49e9-95d1-47697e99eece"), 7, new Guid("5c83ac85-e0eb-4641-a091-0a9588c6c6b7"), "Tempo - 320" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a030cbca-f61c-45f8-9853-5ec01d0f9050"), 8, new Guid("5c83ac85-e0eb-4641-a091-0a9588c6c6b7"), "Tempo - 530" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("57e5458a-2681-49ec-9cf7-1d92555519f6"), 9, new Guid("5c83ac85-e0eb-4641-a091-0a9588c6c6b7"), "Tempo - 303" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ee218bb2-556b-49b5-91f3-b3ea56545a97"), 10, new Guid("5c83ac85-e0eb-4641-a091-0a9588c6c6b7"), "Tempo - 003" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4c7fa099-b77a-452e-9d14-2a0ab531843b"), 0, new Guid("52c75e8a-11e3-43f0-a183-a6cad6fb9447"), "Light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7f2125f6-6ee2-4553-b460-4620ad851fa2"), 1, new Guid("52c75e8a-11e3-43f0-a183-a6cad6fb9447"), "Average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("be9ed0d7-07eb-44d1-9e10-4751d3b00670"), 2, new Guid("52c75e8a-11e3-43f0-a183-a6cad6fb9447"), "Strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("38fa1e2d-c587-4ce0-970d-6131b55add18"), 3, new Guid("52c75e8a-11e3-43f0-a183-a6cad6fb9447"), "Chains" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("75e575c5-6114-4cfd-b962-9ada423cb4e4"), 4, new Guid("52c75e8a-11e3-43f0-a183-a6cad6fb9447"), "Reverse light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8fc844bf-3973-4859-9da8-6d845795dea2"), 5, new Guid("988566a2-ff57-433c-bdfa-606759b6a1fa"), "Trap bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("10358eed-cf8e-45f2-916f-92e3e03b6466"), 5, new Guid("52c75e8a-11e3-43f0-a183-a6cad6fb9447"), "Reverse average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("47f8214c-e054-40c7-82f7-16bc584f01c0"), 0, new Guid("5b14d294-dd3d-4b1e-bbfa-7ad247ffc5fc"), "Knee dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6c5edfee-23f4-4ab1-9c31-0312f9fde64d"), 1, new Guid("5b14d294-dd3d-4b1e-bbfa-7ad247ffc5fc"), "Hip dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("dc7307c8-e40d-4caa-9a73-3a26a28d085a"), 2, new Guid("5b14d294-dd3d-4b1e-bbfa-7ad247ffc5fc"), "Horizontal push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c2cc620b-daa7-4c5c-893f-8ceedfb338fd"), 3, new Guid("5b14d294-dd3d-4b1e-bbfa-7ad247ffc5fc"), "Horizontal pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("34066920-8b4a-41bc-bf1f-f4197f66fd25"), 4, new Guid("5b14d294-dd3d-4b1e-bbfa-7ad247ffc5fc"), "Vertical push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("23e3d9fc-b67b-49aa-ae89-0908972e87bf"), 5, new Guid("5b14d294-dd3d-4b1e-bbfa-7ad247ffc5fc"), "Vertical pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("653e13ee-8d9b-49b3-a520-e131ad2a4436"), 6, new Guid("5b14d294-dd3d-4b1e-bbfa-7ad247ffc5fc"), "Other" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bbef4379-4d5d-418f-8db6-891c578e1974"), 0, new Guid("988566a2-ff57-433c-bdfa-606759b6a1fa"), "Barbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6fb6b2da-a863-4fd0-92fc-56fe04a5605a"), 1, new Guid("988566a2-ff57-433c-bdfa-606759b6a1fa"), "Dumbbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("91f7767f-44d2-462c-8819-0f02d8753f03"), 2, new Guid("988566a2-ff57-433c-bdfa-606759b6a1fa"), "Saftey bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f10d5699-9fe9-4c13-83b1-da3c2749f69c"), 3, new Guid("988566a2-ff57-433c-bdfa-606759b6a1fa"), "Cambered bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8d5faa72-8e4b-4ada-a03c-01ee89b8842c"), 6, new Guid("52c75e8a-11e3-43f0-a183-a6cad6fb9447"), "Reverse strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5ade420d-9492-41c6-8ab4-0e87410f418f"), 6, new Guid("35c1b4f6-bb14-4f78-b884-12f92d953773"), "Reverse strong band" });

            migrationBuilder.InsertData(
                table: "ExerciseTypeTags",
                columns: new[] { "Id", "ExerciseTypeId", "Show", "TagId" },
                values: new object[,]
                {
                    { new Guid("ff4cf856-65d7-45ac-a541-4c5c4bee0206"), new Guid("99f4af86-22d9-42c4-97a7-619c76bf8ba6"), true, new Guid("4fc79f2e-888a-4f4f-86bd-48a269d9128a") },
                    { new Guid("33d1b12e-62af-48ba-a2fd-f0b4bd38b61b"), new Guid("b9f27592-73d7-4092-b23b-acb9a34e2cd5"), false, new Guid("a5cf346c-0a98-416e-b40d-f2dfa864f81e") },
                    { new Guid("8b08ed06-d57b-4d67-8d24-9695177a06f6"), new Guid("bc76842c-16c2-4a2c-8501-4c373c93d798"), false, new Guid("a5cf346c-0a98-416e-b40d-f2dfa864f81e") },
                    { new Guid("3d62533d-6cd2-4f56-a9f2-4d9679105656"), new Guid("560ac9e1-67ad-4868-8167-6c95798d0984"), false, new Guid("a5cf346c-0a98-416e-b40d-f2dfa864f81e") },
                    { new Guid("c0f94654-cd1b-4bbb-9f3b-5fbd0ce2f0ae"), new Guid("b9f27592-73d7-4092-b23b-acb9a34e2cd5"), false, new Guid("d2c08039-9ca0-4fe3-979a-97389232f138") },
                    { new Guid("488b49c6-6c1b-4541-909a-2107fe124036"), new Guid("560ac9e1-67ad-4868-8167-6c95798d0984"), false, new Guid("4b22effa-7f08-4ce7-a1df-307765201381") },
                    { new Guid("586e3c8f-7b57-43b9-8dfc-bf171e66ef7e"), new Guid("b9f27592-73d7-4092-b23b-acb9a34e2cd5"), false, new Guid("9917a54c-6e9c-4a69-b081-8314d6c861b4") },
                    { new Guid("acf5dcbe-8024-4937-99da-3601d4c4a6ff"), new Guid("560ac9e1-67ad-4868-8167-6c95798d0984"), false, new Guid("9917a54c-6e9c-4a69-b081-8314d6c861b4") },
                    { new Guid("5f0b3cfc-6c05-4d3b-a355-38487a051a7e"), new Guid("bc76842c-16c2-4a2c-8501-4c373c93d798"), true, new Guid("be47738a-43f3-43f5-8b9d-dd220dea79a7") },
                    { new Guid("33ce613e-f2c8-4a7a-8208-02e486ad1f52"), new Guid("0ab7c0e4-3df8-48ce-b1fb-6eda07bfcbc1"), false, new Guid("578047e5-3e0d-4237-bc3f-a3ed369f154c") },
                    { new Guid("025a7763-ee61-492d-a186-5c04672ddb52"), new Guid("e340b2ef-558f-4aff-ac1e-653c8ade0215"), true, new Guid("e185926f-c9b1-4da2-906d-5d4a87ff36d9") },
                    { new Guid("77427ced-401a-4086-ad01-9a5d9ad21620"), new Guid("0ab7c0e4-3df8-48ce-b1fb-6eda07bfcbc1"), true, new Guid("255caacf-71fb-44a2-a0e4-6b972730f11c") },
                    { new Guid("20eb86b4-a761-4195-848b-2e760b1396c6"), new Guid("5724ea9e-0908-4077-a551-2b46d6503272"), true, new Guid("3d44594f-a842-4c7b-a126-e155c73ebd4d") },
                    { new Guid("88228849-0460-4440-b210-299074c371fd"), new Guid("e340b2ef-558f-4aff-ac1e-653c8ade0215"), true, new Guid("0581fa51-e818-4a13-a562-6b0c44f2f472") },
                    { new Guid("ef6510a0-adfc-4172-b8d6-e98122f55f8b"), new Guid("5724ea9e-0908-4077-a551-2b46d6503272"), true, new Guid("0581fa51-e818-4a13-a562-6b0c44f2f472") },
                    { new Guid("e309236e-03fa-46be-b654-f9f5d366975d"), new Guid("0ab7c0e4-3df8-48ce-b1fb-6eda07bfcbc1"), true, new Guid("0581fa51-e818-4a13-a562-6b0c44f2f472") },
                    { new Guid("dea2ea37-24a1-4e4c-9aaa-ec84540823d2"), new Guid("e340b2ef-558f-4aff-ac1e-653c8ade0215"), true, new Guid("2a1d0b21-39fd-46c8-8cd9-fd4e2c54f56d") },
                    { new Guid("b6b9c0bf-bc8c-4cbc-9df7-46b92deacd49"), new Guid("e340b2ef-558f-4aff-ac1e-653c8ade0215"), true, new Guid("96ef8e5a-31d6-4ff9-a1d5-9a72b22c7315") },
                    { new Guid("24228f94-d1c0-438c-baab-f3c1be0eb379"), new Guid("0ab7c0e4-3df8-48ce-b1fb-6eda07bfcbc1"), true, new Guid("96ef8e5a-31d6-4ff9-a1d5-9a72b22c7315") },
                    { new Guid("40cd31b5-3a0f-499b-b872-89198230f5cc"), new Guid("e340b2ef-558f-4aff-ac1e-653c8ade0215"), true, new Guid("4ccc837e-5d73-4f2a-b772-38a32a0ec654") },
                    { new Guid("b3ba42ae-cdc4-4279-9762-da69d037b28c"), new Guid("5724ea9e-0908-4077-a551-2b46d6503272"), true, new Guid("4453850a-c98c-47c6-bb90-a23f05d74068") },
                    { new Guid("130991bb-f899-4dd2-91cf-4c04ab963d7f"), new Guid("5724ea9e-0908-4077-a551-2b46d6503272"), true, new Guid("fbafda9d-ba58-466a-8eaf-87dd25e06037") },
                    { new Guid("cf1616b7-f2d3-49fd-b392-00546c42bbfc"), new Guid("e340b2ef-558f-4aff-ac1e-653c8ade0215"), false, new Guid("1c70cb31-d36a-4d91-8335-565d7b8c3b89") },
                    { new Guid("3aafa2bf-0765-4645-8c7e-fa00e211a686"), new Guid("5724ea9e-0908-4077-a551-2b46d6503272"), false, new Guid("1c70cb31-d36a-4d91-8335-565d7b8c3b89") },
                    { new Guid("22b5bf96-e905-46ba-8cf3-83caadec2075"), new Guid("0ab7c0e4-3df8-48ce-b1fb-6eda07bfcbc1"), false, new Guid("1c70cb31-d36a-4d91-8335-565d7b8c3b89") },
                    { new Guid("15bd564f-fde5-4a82-98ab-73b4e12f6831"), new Guid("e340b2ef-558f-4aff-ac1e-653c8ade0215"), false, new Guid("241fbd0e-40e1-4b94-b4c8-89f3a2acd326") },
                    { new Guid("4bd1f613-9938-41c5-b77a-df3f8f46398b"), new Guid("0ab7c0e4-3df8-48ce-b1fb-6eda07bfcbc1"), false, new Guid("d47a77bb-59c7-486e-ad34-6ce1c3748a48") },
                    { new Guid("bf5d4987-10be-49a3-8002-475b208c62b9"), new Guid("e340b2ef-558f-4aff-ac1e-653c8ade0215"), false, new Guid("578047e5-3e0d-4237-bc3f-a3ed369f154c") },
                    { new Guid("44b0aece-93ee-4e32-b284-1487e7b020fd"), new Guid("bc76842c-16c2-4a2c-8501-4c373c93d798"), true, new Guid("762e634d-9ab0-40c9-92df-d9f2576ed97f") },
                    { new Guid("fb78264c-50e7-4a66-abd7-2d64b141610c"), new Guid("bc76842c-16c2-4a2c-8501-4c373c93d798"), true, new Guid("b0397bd9-eb17-45b0-bb08-f59d92813500") },
                    { new Guid("77e3da3c-e80b-454f-9b5a-5d8e1e0d28d2"), new Guid("5724ea9e-0908-4077-a551-2b46d6503272"), true, new Guid("1e39435a-af64-464e-847e-c40f13b02be7") },
                    { new Guid("cb7fbad2-e0b2-46c5-a384-941777b10d76"), new Guid("560ac9e1-67ad-4868-8167-6c95798d0984"), true, new Guid("9d9ed3ab-7369-42d2-9064-f2cfaa61a6e0") },
                    { new Guid("141588bc-9120-4820-8d8b-eb87579f6c50"), new Guid("b9f27592-73d7-4092-b23b-acb9a34e2cd5"), true, new Guid("dbdc410b-492c-48d6-9798-0646eef56f02") },
                    { new Guid("9ff98eab-75be-4d97-ba1a-e8630b39ac18"), new Guid("5e42f2ef-4d54-4689-8e9a-d6467940c64b"), true, new Guid("44c40fd8-6973-4765-aa14-bc314290f95f") },
                    { new Guid("6b82a64a-7cfb-43fc-b108-616dba0446b9"), new Guid("99f4af86-22d9-42c4-97a7-619c76bf8ba6"), false, new Guid("e631ee84-ca3e-4bf6-93ee-2d98afefdadd") },
                    { new Guid("69702601-2cd3-42dc-b993-6ccf8730a8ae"), new Guid("676626d7-2eb4-480b-a126-d87a08f3a296"), false, new Guid("d4c0d33c-8a72-47d4-aa72-e858ef3dce0c") },
                    { new Guid("2f6a89a5-f35d-48ae-8e52-d2d7a43c9a29"), new Guid("99f4af86-22d9-42c4-97a7-619c76bf8ba6"), false, new Guid("96276c9d-8ea3-4a8e-9140-b912a87a002e") },
                    { new Guid("0b090d6d-39cf-473e-8311-adf8e99259d6"), new Guid("676626d7-2eb4-480b-a126-d87a08f3a296"), false, new Guid("7dd3668a-c7a5-4a3a-9891-770288e14912") },
                    { new Guid("e5f35c0f-f006-4844-bb5b-1845187a9078"), new Guid("5e42f2ef-4d54-4689-8e9a-d6467940c64b"), false, new Guid("7dd3668a-c7a5-4a3a-9891-770288e14912") },
                    { new Guid("83631cec-f783-42d4-8586-d26dccf393f1"), new Guid("99f4af86-22d9-42c4-97a7-619c76bf8ba6"), false, new Guid("7dd3668a-c7a5-4a3a-9891-770288e14912") },
                    { new Guid("a7c02b0f-dfc2-4ccb-b351-721a05e63db5"), new Guid("5e42f2ef-4d54-4689-8e9a-d6467940c64b"), true, new Guid("ce5184b3-9f69-4a99-84c3-119b2f5b55e0") },
                    { new Guid("a35a8994-4a88-4dee-92f5-f67227fef444"), new Guid("5e42f2ef-4d54-4689-8e9a-d6467940c64b"), true, new Guid("d39f9218-506f-4517-b9ec-41180f3aafd3") },
                    { new Guid("19769a22-54a2-45e8-8405-eac3fb2e5fb2"), new Guid("99f4af86-22d9-42c4-97a7-619c76bf8ba6"), true, new Guid("32d7e113-4bd5-4cf1-92f4-ca09e3992980") },
                    { new Guid("a48fdb56-a310-42be-9c09-16e95d2df9cc"), new Guid("676626d7-2eb4-480b-a126-d87a08f3a296"), true, new Guid("2cdc5f29-ee79-4874-9fe6-6c9b0160a67b") },
                    { new Guid("05c6876f-78e4-4963-909a-7cd8b8c5c1e1"), new Guid("99f4af86-22d9-42c4-97a7-619c76bf8ba6"), true, new Guid("2cdc5f29-ee79-4874-9fe6-6c9b0160a67b") },
                    { new Guid("5d2656db-3543-4451-84d7-ccf1376e9ed5"), new Guid("676626d7-2eb4-480b-a126-d87a08f3a296"), false, new Guid("e631ee84-ca3e-4bf6-93ee-2d98afefdadd") },
                    { new Guid("c128bd11-71b2-4e8d-ab24-a4e4db00f800"), new Guid("676626d7-2eb4-480b-a126-d87a08f3a296"), true, new Guid("8f4591c1-f06a-4329-8aec-330a4fa2b390") },
                    { new Guid("4e0c80f7-b7df-4a8e-9e48-6dc242d97adc"), new Guid("b9f27592-73d7-4092-b23b-acb9a34e2cd5"), true, new Guid("9d9ed3ab-7369-42d2-9064-f2cfaa61a6e0") },
                    { new Guid("75eb933f-3a41-4714-bc03-30f56bd6d78c"), new Guid("560ac9e1-67ad-4868-8167-6c95798d0984"), true, new Guid("bbef4379-4d5d-418f-8db6-891c578e1974") },
                    { new Guid("34a7d8af-fd67-4953-9e67-7c58098d5844"), new Guid("bc76842c-16c2-4a2c-8501-4c373c93d798"), true, new Guid("bbef4379-4d5d-418f-8db6-891c578e1974") },
                    { new Guid("e86503b2-2f5d-4104-a6b0-e6bf0a29785a"), new Guid("99f4af86-22d9-42c4-97a7-619c76bf8ba6"), true, new Guid("32beeaeb-5350-4b48-96bf-9355cff7182f") },
                    { new Guid("b0a3a958-2eaa-4667-ae7b-2a66362fb076"), new Guid("bc76842c-16c2-4a2c-8501-4c373c93d798"), true, new Guid("dc7307c8-e40d-4caa-9a73-3a26a28d085a") },
                    { new Guid("f73b4a09-b3bb-44ca-9461-e618830b7c37"), new Guid("b9f27592-73d7-4092-b23b-acb9a34e2cd5"), true, new Guid("bbef4379-4d5d-418f-8db6-891c578e1974") },
                    { new Guid("f2a4f566-f05f-4c7d-9546-dfe658397e52"), new Guid("b9f27592-73d7-4092-b23b-acb9a34e2cd5"), true, new Guid("47f8214c-e054-40c7-82f7-16bc584f01c0") },
                    { new Guid("7b70ae6c-f72e-48c8-bc8d-4778cec9e650"), new Guid("676626d7-2eb4-480b-a126-d87a08f3a296"), true, new Guid("132ded0b-6ab0-4378-91c3-9cbda3df0a79") },
                    { new Guid("537beef0-ade1-43e3-9e22-4575a7d66b93"), new Guid("5e42f2ef-4d54-4689-8e9a-d6467940c64b"), true, new Guid("53feccb3-ba48-4119-9aff-1d48fe51d930") },
                    { new Guid("7a3ecb0c-5868-4345-807c-5c6cc7a1cf25"), new Guid("99f4af86-22d9-42c4-97a7-619c76bf8ba6"), true, new Guid("8f4591c1-f06a-4329-8aec-330a4fa2b390") },
                    { new Guid("8f5032e7-f4b4-4d33-9d0c-b58d2fbe8683"), new Guid("5e42f2ef-4d54-4689-8e9a-d6467940c64b"), true, new Guid("8f4591c1-f06a-4329-8aec-330a4fa2b390") },
                    { new Guid("ae86d649-15e3-4965-90f8-e453b26a21f5"), new Guid("560ac9e1-67ad-4868-8167-6c95798d0984"), true, new Guid("6c5edfee-23f4-4ab1-9c31-0312f9fde64d") },
                    { new Guid("ab003514-e65b-4d06-aa51-2201be52b2e8"), new Guid("b9f27592-73d7-4092-b23b-acb9a34e2cd5"), true, new Guid("ecefcba0-7ad4-4bfc-bb78-11130336e8a0") }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d1f857d5-4c78-4930-a0f7-a4dc281a642d"), 3, new Guid("da613513-c07e-4d60-b598-7dc7bf446a85"), "Pause - 3 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6cf6628e-9510-4f04-a5e7-1d7fefcac5af"), 2, new Guid("da613513-c07e-4d60-b598-7dc7bf446a85"), "Pause - 2 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7a51ada8-84bb-49ba-aca8-6d9dd083cd5b"), 1, new Guid("da613513-c07e-4d60-b598-7dc7bf446a85"), "Touch and go" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6a061105-0d86-48e0-8386-538abded095e"), 3, new Guid("04c64b79-bb52-4b4c-818d-0bd9ab0f3c2e"), "Sumo" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ae74ff95-9c32-4587-b856-d4c7ee07c3b0"), 6, new Guid("04c64b79-bb52-4b4c-818d-0bd9ab0f3c2e"), "Feet up" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("aa68aab3-529a-4d30-aeff-2ddb2de5e328"), 5, new Guid("04c64b79-bb52-4b4c-818d-0bd9ab0f3c2e"), "Stiff legged" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4641cf29-7efc-46f5-9e9e-1ef94b78f8e4"), 4, new Guid("04c64b79-bb52-4b4c-818d-0bd9ab0f3c2e"), "Conventional" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2f78b03b-83cf-4732-bf49-393571cf66a6"), 4, new Guid("da613513-c07e-4d60-b598-7dc7bf446a85"), "Pause - 5 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d37e6819-78ec-499b-a0c6-152028977241"), 2, new Guid("04c64b79-bb52-4b4c-818d-0bd9ab0f3c2e"), "Wide" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1dbdd880-d560-4366-a6ea-56bcc1033892"), 0, new Guid("da613513-c07e-4d60-b598-7dc7bf446a85"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("faa970e4-d68e-4e1d-b613-039a6007a829"), 5, new Guid("da613513-c07e-4d60-b598-7dc7bf446a85"), "Pause - 7 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("cf4faca0-8d6a-4c8e-9c34-6c3877635402"), 0, new Guid("ab36a8f0-1579-4182-8632-eb405e52396b"), "Light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fac1d51d-7914-422b-9789-65f2e099e226"), 7, new Guid("da613513-c07e-4d60-b598-7dc7bf446a85"), "Tempo - 320" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("360f8910-8124-4a16-88c4-29e22c8bd44e"), 8, new Guid("da613513-c07e-4d60-b598-7dc7bf446a85"), "Tempo - 530" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f6466de1-0d9e-4114-a0d0-89626e5bd4a8"), 9, new Guid("da613513-c07e-4d60-b598-7dc7bf446a85"), "Tempo - 303" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ac188a65-7f7b-4a11-b17e-2a409630b9d5"), 10, new Guid("da613513-c07e-4d60-b598-7dc7bf446a85"), "Tempo - 003" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("688f882d-3750-4fdf-9453-a87d1fdabf7a"), 1, new Guid("ab36a8f0-1579-4182-8632-eb405e52396b"), "Average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1de4cd7f-9ba8-4dd1-b5a6-11e2dd580e8d"), 2, new Guid("ab36a8f0-1579-4182-8632-eb405e52396b"), "Strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2bf31f24-00f3-4490-ba8b-5130afd00974"), 3, new Guid("ab36a8f0-1579-4182-8632-eb405e52396b"), "Chains" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3f0f89ed-7d2c-4b3a-bd2c-1872408792d4"), 4, new Guid("ab36a8f0-1579-4182-8632-eb405e52396b"), "Reverse light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1057420b-008c-4caa-bc02-787c1bfee03c"), 5, new Guid("ab36a8f0-1579-4182-8632-eb405e52396b"), "Reverse average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0321cdf7-20eb-4998-8a26-ea56eb255378"), 6, new Guid("ab36a8f0-1579-4182-8632-eb405e52396b"), "Reverse strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fcb3f4a4-80b3-4bbc-b423-2dbf528f959d"), 1, new Guid("04c64b79-bb52-4b4c-818d-0bd9ab0f3c2e"), "Narrow" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("40e2c5ef-93fc-46f1-9675-4cddf3644363"), 6, new Guid("da613513-c07e-4d60-b598-7dc7bf446a85"), "Tempo - 600" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1bafc8ef-4e6b-48a9-aeb7-a03d9b6c9459"), 0, new Guid("04c64b79-bb52-4b4c-818d-0bd9ab0f3c2e"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f83083c6-4ebd-40e0-a75c-f23da264dc1e"), 8, new Guid("9ac2708b-377a-4f18-a67f-aa34a57700c2"), "Two board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ad8590bf-1c93-45b3-8ec9-3fe4aa44d66b"), 11, new Guid("9ac2708b-377a-4f18-a67f-aa34a57700c2"), "Five board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("baeb278f-ec64-4f0f-a929-f43d3e44defd"), 2, new Guid("84fe3332-8aa4-4f4f-8e2c-fb8d7b89c390"), "Low bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("48c10e29-8744-448e-874c-3f29940c02ce"), 1, new Guid("84fe3332-8aa4-4f4f-8e2c-fb8d7b89c390"), "High bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c39d2f24-71a9-4c07-90b7-7b86550e3144"), 0, new Guid("84fe3332-8aa4-4f4f-8e2c-fb8d7b89c390"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("eef97a48-489f-48b9-bf2a-781e46264bc4"), 7, new Guid("5dff48b3-13a5-4fc2-8ec3-e77e1b916413"), "Machine" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d033c31d-fd51-4e1f-a372-0c1c2d490e71"), 6, new Guid("5dff48b3-13a5-4fc2-8ec3-e77e1b916413"), "Buffalo bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b4b49e8a-398b-4f8f-8965-bb86465ac62c"), 5, new Guid("5dff48b3-13a5-4fc2-8ec3-e77e1b916413"), "Trap bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a79c99ae-cb5f-439e-8d9c-e8b1ee7830a7"), 4, new Guid("5dff48b3-13a5-4fc2-8ec3-e77e1b916413"), "Neutral-grip bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7f8e8cec-63bc-448d-a885-17fd5dc52f4f"), 3, new Guid("5dff48b3-13a5-4fc2-8ec3-e77e1b916413"), "Cambered bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("81fac015-dfe8-47ed-9dc3-eb123c443df5"), 3, new Guid("84fe3332-8aa4-4f4f-8e2c-fb8d7b89c390"), "Front rack" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("206e9589-2a4b-495c-9a4f-76d2c1e76389"), 2, new Guid("5dff48b3-13a5-4fc2-8ec3-e77e1b916413"), "Saftey bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0f23b092-5697-48a7-a1fd-27a319891ade"), 0, new Guid("5dff48b3-13a5-4fc2-8ec3-e77e1b916413"), "Barbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2eabf993-a8cd-4efb-93f3-4caf9abf5abe"), 6, new Guid("15409f18-cf11-46b6-a4d1-93d20df98aa2"), "Other" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("28267077-e698-4d57-b8b7-07adc1f97c4f"), 5, new Guid("15409f18-cf11-46b6-a4d1-93d20df98aa2"), "Vertical pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fe469279-003f-4a6b-bfdc-5b8af1be97a2"), 4, new Guid("15409f18-cf11-46b6-a4d1-93d20df98aa2"), "Vertical push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("12a1c066-2914-4055-aff4-e2085bd4ae4d"), 3, new Guid("15409f18-cf11-46b6-a4d1-93d20df98aa2"), "Horizontal pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("60612d74-e879-4ae1-b5ab-4e28d01d996f"), 2, new Guid("15409f18-cf11-46b6-a4d1-93d20df98aa2"), "Horizontal push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("61ab6c60-cdbb-47dc-95d3-85b3f66eed8d"), 1, new Guid("15409f18-cf11-46b6-a4d1-93d20df98aa2"), "Hip dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b1687b6a-b7f8-418d-bbc1-aff264d9e51b"), 0, new Guid("15409f18-cf11-46b6-a4d1-93d20df98aa2"), "Knee dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fbeb5d1f-fedd-418c-8885-7d7bc2c9fbc8"), 1, new Guid("5dff48b3-13a5-4fc2-8ec3-e77e1b916413"), "Dumbbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("63e7f41a-82c8-4694-ab02-4985d38dddaf"), 0, new Guid("7671b037-bcbe-4f03-9327-0558a45cac97"), "Belt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("55daa53f-5d63-46fa-9b0e-9a4a875118f8"), 1, new Guid("7671b037-bcbe-4f03-9327-0558a45cac97"), "Knee sleeves" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5cdefc39-ab90-46ca-ba6f-d173b8a13c3e"), 2, new Guid("7671b037-bcbe-4f03-9327-0558a45cac97"), "Knee wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ed55c592-4b62-4666-a933-797b93e9644b"), 10, new Guid("9ac2708b-377a-4f18-a67f-aa34a57700c2"), "Four board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("101192ca-33fa-443c-83a4-721aa6fb93cf"), 9, new Guid("9ac2708b-377a-4f18-a67f-aa34a57700c2"), "Three board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("915cf1a2-34de-40e1-b2d1-565ecdc7ec57"), 7, new Guid("9ac2708b-377a-4f18-a67f-aa34a57700c2"), "Half board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("83cf40f3-989c-47ed-acca-ca8fc1a36dc6"), 6, new Guid("9ac2708b-377a-4f18-a67f-aa34a57700c2"), "Two inch deficit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a3572d39-f308-4d98-8836-b295fbc510ea"), 5, new Guid("9ac2708b-377a-4f18-a67f-aa34a57700c2"), "High pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0b928d4d-0c8a-42bc-b527-644738c66549"), 4, new Guid("9ac2708b-377a-4f18-a67f-aa34a57700c2"), "Middle pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7fe7dc2e-fd2d-4f11-9eab-6f989fa28370"), 3, new Guid("9ac2708b-377a-4f18-a67f-aa34a57700c2"), "Low pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("441d2fd5-43c5-457a-8d04-2b28ebe66454"), 2, new Guid("9ac2708b-377a-4f18-a67f-aa34a57700c2"), "Towel" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c5f714ed-d3e8-4b24-8a09-eb1014280ad3"), 1, new Guid("9ac2708b-377a-4f18-a67f-aa34a57700c2"), "Box" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("de981b9b-da31-4ff5-84a9-4d0e52a33040"), 0, new Guid("9ac2708b-377a-4f18-a67f-aa34a57700c2"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c121c7c1-5012-40df-8a92-1d953dadba1a"), 3, new Guid("4c0956b3-412d-4323-9b95-02bbfa00406e"), "Wide grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d0e8f678-0cd0-4955-a94a-1e660d63291d"), 2, new Guid("4c0956b3-412d-4323-9b95-02bbfa00406e"), "Close grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("26d5d745-4aab-4e5b-892e-5bb35c70a38e"), 1, new Guid("4c0956b3-412d-4323-9b95-02bbfa00406e"), "Reverse grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fa61d13e-387b-4021-8fa2-cd1a0dd66dc7"), 0, new Guid("4c0956b3-412d-4323-9b95-02bbfa00406e"), "Snatch grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b5883c28-6f1c-4b7d-ba8e-8a5b54ee8155"), 7, new Guid("7671b037-bcbe-4f03-9327-0558a45cac97"), "Wrist wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("23918192-4f4c-4c39-ba0d-be9fc358e280"), 7, new Guid("7671b037-bcbe-4f03-9327-0558a45cac97"), "Deadlift suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("abbdccdc-224e-4328-92ca-9b5c023fe994"), 6, new Guid("7671b037-bcbe-4f03-9327-0558a45cac97"), "Bench shirt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("add6e0c3-718a-4e91-b402-1de1b13f4e7c"), 4, new Guid("7671b037-bcbe-4f03-9327-0558a45cac97"), "Breifs" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0f35f858-5a04-44e8-bce5-0f00a5cd2676"), 3, new Guid("7671b037-bcbe-4f03-9327-0558a45cac97"), "Slingshot" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7ed4b5e6-7bdf-498d-b0f7-30697c42852d"), 12, new Guid("9ac2708b-377a-4f18-a67f-aa34a57700c2"), "Towel - 8 cm " });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("195a8073-63b2-4676-949c-4c017c3c9b67"), 5, new Guid("7671b037-bcbe-4f03-9327-0558a45cac97"), "Squat suit" });

            migrationBuilder.InsertData(
                table: "ExerciseTypeTags",
                columns: new[] { "Id", "ExerciseTypeId", "Show", "TagId" },
                values: new object[,]
                {
                    { new Guid("44432a08-1a9c-4d2c-808e-9e3988c543c8"), new Guid("1b4de829-24a5-4dfb-871e-0d158fd13c39"), true, new Guid("b1687b6a-b7f8-418d-bbc1-aff264d9e51b") },
                    { new Guid("d2915d21-b883-4a1d-abdd-5127cf2109a0"), new Guid("1b4de829-24a5-4dfb-871e-0d158fd13c39"), false, new Guid("1dbdd880-d560-4366-a6ea-56bcc1033892") },
                    { new Guid("00a49a49-5302-4a94-b65e-158a76773036"), new Guid("94abc1b7-a5f2-4679-973b-0cce6acef187"), false, new Guid("6a061105-0d86-48e0-8386-538abded095e") },
                    { new Guid("f40356e3-a320-4591-ba3e-eee023fde8f2"), new Guid("1b4de829-24a5-4dfb-871e-0d158fd13c39"), false, new Guid("1bafc8ef-4e6b-48a9-aeb7-a03d9b6c9459") },
                    { new Guid("6070fa30-c1c6-40ca-bd7d-ee12da23936c"), new Guid("94abc1b7-a5f2-4679-973b-0cce6acef187"), false, new Guid("de981b9b-da31-4ff5-84a9-4d0e52a33040") },
                    { new Guid("1f02fe75-8ca1-42e3-b03a-6613cb581e8c"), new Guid("83d49648-7271-40a7-b6eb-34a2756b0383"), false, new Guid("de981b9b-da31-4ff5-84a9-4d0e52a33040") },
                    { new Guid("71198617-d9a1-4e0f-8599-ddfaeb5699b7"), new Guid("1b4de829-24a5-4dfb-871e-0d158fd13c39"), false, new Guid("de981b9b-da31-4ff5-84a9-4d0e52a33040") },
                    { new Guid("bd980643-22bb-4593-92e8-5a8b2d6ce18c"), new Guid("83d49648-7271-40a7-b6eb-34a2756b0383"), true, new Guid("c121c7c1-5012-40df-8a92-1d953dadba1a") },
                    { new Guid("d5a05c9f-1bb5-4e80-8d96-b6950e0343f6"), new Guid("83d49648-7271-40a7-b6eb-34a2756b0383"), true, new Guid("b5883c28-6f1c-4b7d-ba8e-8a5b54ee8155") },
                    { new Guid("5f82f3b4-aaad-40bb-b3b9-9160267299b7"), new Guid("1b4de829-24a5-4dfb-871e-0d158fd13c39"), true, new Guid("55daa53f-5d63-46fa-9b0e-9a4a875118f8") },
                    { new Guid("d2a69467-04e0-494b-a1f8-e27a9a1ba785"), new Guid("94abc1b7-a5f2-4679-973b-0cce6acef187"), true, new Guid("63e7f41a-82c8-4694-ab02-4985d38dddaf") },
                    { new Guid("45bd1864-6927-4245-9213-f20b60ce588e"), new Guid("1b4de829-24a5-4dfb-871e-0d158fd13c39"), true, new Guid("63e7f41a-82c8-4694-ab02-4985d38dddaf") },
                    { new Guid("63eb5635-7b17-44ca-96e8-6eddf7df109b"), new Guid("1b4de829-24a5-4dfb-871e-0d158fd13c39"), true, new Guid("baeb278f-ec64-4f0f-a929-f43d3e44defd") },
                    { new Guid("6183026c-b8f0-419a-9766-8daf49a58356"), new Guid("94abc1b7-a5f2-4679-973b-0cce6acef187"), true, new Guid("0f23b092-5697-48a7-a1fd-27a319891ade") },
                    { new Guid("019b3000-d292-4e07-ba9e-a17f26719480"), new Guid("83d49648-7271-40a7-b6eb-34a2756b0383"), true, new Guid("0f23b092-5697-48a7-a1fd-27a319891ade") },
                    { new Guid("647ede11-5832-41dd-a70a-2edc36ef8006"), new Guid("1b4de829-24a5-4dfb-871e-0d158fd13c39"), true, new Guid("0f23b092-5697-48a7-a1fd-27a319891ade") },
                    { new Guid("954ae433-0155-4406-8efb-bcd29d51c278"), new Guid("83d49648-7271-40a7-b6eb-34a2756b0383"), true, new Guid("60612d74-e879-4ae1-b5ab-4e28d01d996f") },
                    { new Guid("6632abb9-4264-4aa3-aef5-fc7a241e7aee"), new Guid("94abc1b7-a5f2-4679-973b-0cce6acef187"), true, new Guid("61ab6c60-cdbb-47dc-95d3-85b3f66eed8d") },
                    { new Guid("8d7d5b6c-c4b0-4aa8-afac-77a25f4f1b05"), new Guid("94abc1b7-a5f2-4679-973b-0cce6acef187"), false, new Guid("1dbdd880-d560-4366-a6ea-56bcc1033892") },
                    { new Guid("d7f54112-4539-42c4-9f33-b40df95a3614"), new Guid("83d49648-7271-40a7-b6eb-34a2756b0383"), true, new Guid("d1f857d5-4c78-4930-a0f7-a4dc281a642d") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_ExerciseTypes_ExerciseTypeId",
                table: "Exercises",
                column: "ExerciseTypeId",
                principalTable: "ExerciseTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Trainings_TrainingId",
                table: "Exercises",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_ExerciseTypes_ExerciseTypeId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Trainings_TrainingId",
                table: "Exercises");

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("00a49a49-5302-4a94-b65e-158a76773036"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("019b3000-d292-4e07-ba9e-a17f26719480"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("025a7763-ee61-492d-a186-5c04672ddb52"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("05c6876f-78e4-4963-909a-7cd8b8c5c1e1"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("0b090d6d-39cf-473e-8311-adf8e99259d6"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("130991bb-f899-4dd2-91cf-4c04ab963d7f"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("141588bc-9120-4820-8d8b-eb87579f6c50"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("15bd564f-fde5-4a82-98ab-73b4e12f6831"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("19769a22-54a2-45e8-8405-eac3fb2e5fb2"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("1f02fe75-8ca1-42e3-b03a-6613cb581e8c"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("20eb86b4-a761-4195-848b-2e760b1396c6"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("22b5bf96-e905-46ba-8cf3-83caadec2075"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("24228f94-d1c0-438c-baab-f3c1be0eb379"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("2f6a89a5-f35d-48ae-8e52-d2d7a43c9a29"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("33ce613e-f2c8-4a7a-8208-02e486ad1f52"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("33d1b12e-62af-48ba-a2fd-f0b4bd38b61b"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("34a7d8af-fd67-4953-9e67-7c58098d5844"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("3aafa2bf-0765-4645-8c7e-fa00e211a686"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("3d62533d-6cd2-4f56-a9f2-4d9679105656"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("40cd31b5-3a0f-499b-b872-89198230f5cc"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("44432a08-1a9c-4d2c-808e-9e3988c543c8"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("44b0aece-93ee-4e32-b284-1487e7b020fd"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("45bd1864-6927-4245-9213-f20b60ce588e"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("488b49c6-6c1b-4541-909a-2107fe124036"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("4bd1f613-9938-41c5-b77a-df3f8f46398b"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("4e0c80f7-b7df-4a8e-9e48-6dc242d97adc"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("537beef0-ade1-43e3-9e22-4575a7d66b93"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("586e3c8f-7b57-43b9-8dfc-bf171e66ef7e"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("5d2656db-3543-4451-84d7-ccf1376e9ed5"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("5f0b3cfc-6c05-4d3b-a355-38487a051a7e"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("5f82f3b4-aaad-40bb-b3b9-9160267299b7"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("6070fa30-c1c6-40ca-bd7d-ee12da23936c"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("6183026c-b8f0-419a-9766-8daf49a58356"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("63eb5635-7b17-44ca-96e8-6eddf7df109b"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("647ede11-5832-41dd-a70a-2edc36ef8006"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("6632abb9-4264-4aa3-aef5-fc7a241e7aee"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("69702601-2cd3-42dc-b993-6ccf8730a8ae"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("6b82a64a-7cfb-43fc-b108-616dba0446b9"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("71198617-d9a1-4e0f-8599-ddfaeb5699b7"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("75eb933f-3a41-4714-bc03-30f56bd6d78c"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("77427ced-401a-4086-ad01-9a5d9ad21620"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("77e3da3c-e80b-454f-9b5a-5d8e1e0d28d2"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("7a3ecb0c-5868-4345-807c-5c6cc7a1cf25"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("7b70ae6c-f72e-48c8-bc8d-4778cec9e650"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("83631cec-f783-42d4-8586-d26dccf393f1"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("88228849-0460-4440-b210-299074c371fd"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("8b08ed06-d57b-4d67-8d24-9695177a06f6"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("8d7d5b6c-c4b0-4aa8-afac-77a25f4f1b05"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("8f5032e7-f4b4-4d33-9d0c-b58d2fbe8683"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("954ae433-0155-4406-8efb-bcd29d51c278"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("9ff98eab-75be-4d97-ba1a-e8630b39ac18"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("a35a8994-4a88-4dee-92f5-f67227fef444"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("a48fdb56-a310-42be-9c09-16e95d2df9cc"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("a7c02b0f-dfc2-4ccb-b351-721a05e63db5"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("ab003514-e65b-4d06-aa51-2201be52b2e8"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("acf5dcbe-8024-4937-99da-3601d4c4a6ff"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("ae86d649-15e3-4965-90f8-e453b26a21f5"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("b0a3a958-2eaa-4667-ae7b-2a66362fb076"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("b3ba42ae-cdc4-4279-9762-da69d037b28c"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("b6b9c0bf-bc8c-4cbc-9df7-46b92deacd49"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("bd980643-22bb-4593-92e8-5a8b2d6ce18c"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("bf5d4987-10be-49a3-8002-475b208c62b9"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("c0f94654-cd1b-4bbb-9f3b-5fbd0ce2f0ae"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("c128bd11-71b2-4e8d-ab24-a4e4db00f800"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("cb7fbad2-e0b2-46c5-a384-941777b10d76"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("cf1616b7-f2d3-49fd-b392-00546c42bbfc"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("d2915d21-b883-4a1d-abdd-5127cf2109a0"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("d2a69467-04e0-494b-a1f8-e27a9a1ba785"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("d5a05c9f-1bb5-4e80-8d96-b6950e0343f6"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("d7f54112-4539-42c4-9f33-b40df95a3614"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("dea2ea37-24a1-4e4c-9aaa-ec84540823d2"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("e309236e-03fa-46be-b654-f9f5d366975d"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("e5f35c0f-f006-4844-bb5b-1845187a9078"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("e86503b2-2f5d-4104-a6b0-e6bf0a29785a"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("ef6510a0-adfc-4172-b8d6-e98122f55f8b"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("f2a4f566-f05f-4c7d-9546-dfe658397e52"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("f40356e3-a320-4591-ba3e-eee023fde8f2"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("f73b4a09-b3bb-44ca-9461-e618830b7c37"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("fb78264c-50e7-4a66-abd7-2d64b141610c"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("ff4cf856-65d7-45ac-a541-4c5c4bee0206"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("083616fa-326c-4152-8724-72d4fea99064"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("2603c074-afcc-46ec-b028-a5c65b8cc813"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("2e82a743-c1b0-4dd1-a124-81608a6aa97e"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("3315f2a6-19b6-4af0-89c2-138cb638bc51"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("5bca3bb0-6e97-40f4-b283-6ea631f446b3"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("60f408df-5afd-41f0-9aa4-765f95c8e57b"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("8d83eb09-954f-4748-b775-5a11b767f26f"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("a884025c-4bc8-4c5f-b056-1be64de06e15"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("adf177b0-9da9-473d-921f-bf71fbfeae20"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("c55ed659-212f-4f3f-8b11-3919155cbd58"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("c6ff475e-a802-440f-bd99-98bec7edc32d"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("ff83dd0d-6fe5-43d3-99b8-f61324cdb703"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("01294e49-0f57-4ed6-8132-9d230bba8325"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("02e6fb99-6b05-4701-a9be-e971b6fbf307"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0321cdf7-20eb-4998-8a26-ea56eb255378"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("07428cba-82b6-44a0-a08e-9252cd9e700e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("07fe13c9-8c21-4c3b-83c5-5ef305a347be"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0b4c41f2-e4d9-4e25-adb9-1247f2776d31"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0b928d4d-0c8a-42bc-b527-644738c66549"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0f2a7e7a-6188-4478-8c6c-fe7cf1ee7e6b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0f35f858-5a04-44e8-bce5-0f00a5cd2676"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("101192ca-33fa-443c-83a4-721aa6fb93cf"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("10358eed-cf8e-45f2-916f-92e3e03b6466"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1057420b-008c-4caa-bc02-787c1bfee03c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("12a1c066-2914-4055-aff4-e2085bd4ae4d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("12d89d4b-0ce4-44ea-9026-2b81fa72ab13"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1508e305-b42f-463b-b618-cba97e811175"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("195a8073-63b2-4676-949c-4c017c3c9b67"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1ce1b1d1-1996-4537-adb4-840646a918a5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1de4cd7f-9ba8-4dd1-b5a6-11e2dd580e8d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("206e9589-2a4b-495c-9a4f-76d2c1e76389"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("22a119b9-7d2f-4523-8f3d-a8f9ccbb6875"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("237bbd47-f7db-4e85-951a-99a52f02c501"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("23918192-4f4c-4c39-ba0d-be9fc358e280"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("23e3d9fc-b67b-49aa-ae89-0908972e87bf"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("26052ea7-3bf3-460b-927b-db0b5ba41ec2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2621ebd2-03cc-4ece-b3ed-3ce5901bc2fe"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("26d5d745-4aab-4e5b-892e-5bb35c70a38e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2730e96f-2377-4e20-b784-b3b016c87877"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("28267077-e698-4d57-b8b7-07adc1f97c4f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("283b7f46-61e5-406b-8229-324ea7cc82d2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("28a2e23d-361f-4873-8fcd-ebd7caf25037"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("28c94875-8b49-4e83-973a-cbd06dc03268"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2a10639d-2365-4f8d-bc53-4549cd4a1c7e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2af89b55-a72c-43a0-a8cc-14dbde178ea0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2bb4e1ba-d6bb-4f0f-8bd6-354254003a73"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2bf31f24-00f3-4490-ba8b-5130afd00974"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2cfec3d2-57f6-430f-8715-17cad59a7aba"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2eabf993-a8cd-4efb-93f3-4caf9abf5abe"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2f78b03b-83cf-4732-bf49-393571cf66a6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("326cd8f4-c47e-43c5-8f7b-109db5f3579e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("33247a96-b69c-4d6b-a151-e2b98594cb22"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3353a5f2-c90b-42a7-a190-964ed34625ac"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("33f54a78-aa7b-4132-a222-e11298c7d8d7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("34066920-8b4a-41bc-bf1f-f4197f66fd25"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("360f8910-8124-4a16-88c4-29e22c8bd44e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3898d8d1-4639-45e2-b5b7-3966532d65b6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("38fa1e2d-c587-4ce0-970d-6131b55add18"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3a320dd2-0da9-4433-a13a-d4f9796c9094"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3a9e6da1-27fa-4c4e-b8aa-e41df82f13d0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3c4be06a-fa24-44d7-9864-dc0120f43e82"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3f0f89ed-7d2c-4b3a-bd2c-1872408792d4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("40d7e8b5-7293-47bd-9af4-6afcf92f36e4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("40e2c5ef-93fc-46f1-9675-4cddf3644363"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("42cdabc4-7fe5-464e-a5a9-f77c657965b2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("431ba3af-2990-4788-a461-d409a88e48e8"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4341face-a862-42d2-bf47-781d46dbe1de"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("43544f20-0535-452e-95a1-6cc4a18dcde8"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("441d2fd5-43c5-457a-8d04-2b28ebe66454"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("45bb89ac-4111-4a60-b5a3-4c4d7bbffa10"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4641cf29-7efc-46f5-9e9e-1ef94b78f8e4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("46ca4f74-69b3-448c-8ee9-ab8ad839d417"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("48c10e29-8744-448e-874c-3f29940c02ce"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4c7fa099-b77a-452e-9d14-2a0ab531843b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4fa04400-a691-42dd-b1da-1a919fc57e26"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("52aa6b65-5b9d-4d19-989e-3549a30c0ebe"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("53d5e94e-7909-4746-a70d-9ee14d9e8338"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("555a2ff7-b1a2-4098-867a-cec5f7df4008"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("56ebf7b4-5831-48d8-8f44-a028d009e71c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("57e5458a-2681-49ec-9cf7-1d92555519f6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("588cbc8c-4727-4338-9f79-33a696453810"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5a53bffa-03b0-4907-b7dc-b84a1a280f33"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5ade420d-9492-41c6-8ab4-0e87410f418f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5badd649-9804-4502-b017-5ef31e3eb36f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5c70f9ee-39c5-4814-9a0e-4d2cdc258716"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5cdefc39-ab90-46ca-ba6f-d173b8a13c3e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5df4db8f-b374-426f-953d-8f5413b92137"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("600f7a21-44fe-4baf-90d7-ed25c37f309c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("653e13ee-8d9b-49b3-a520-e131ad2a4436"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("670805a7-50ce-40de-8a39-bcaf26576c69"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("678b623a-0fcc-4587-88f7-9ec1c7f5ebbe"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("688f882d-3750-4fdf-9453-a87d1fdabf7a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6bd75938-c045-4bd2-a0b2-1ab2f5534282"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6cf6628e-9510-4f04-a5e7-1d7fefcac5af"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6e0a34ff-3047-4443-b802-d15a78980f8f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6f9ff983-a115-49b3-be0e-f89eef194bb5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6fb6b2da-a863-4fd0-92fc-56fe04a5605a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("71b73f59-98a3-4a51-940b-5616d7ce7307"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("72b6eb16-6183-42e0-b175-2349ac305d34"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("72ef428b-654d-4f30-918f-8639d17a71e3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("742c516d-3dc0-477b-ae02-eb8d7fffaf14"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("75e575c5-6114-4cfd-b962-9ada423cb4e4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("768f3bec-e886-408d-867e-12c3a2a54f7c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("78a2dcca-a2c0-4820-b2be-1464de9cb746"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("79aba85c-90e8-488d-8ff2-439cda37e675"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7a51ada8-84bb-49ba-aca8-6d9dd083cd5b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7d6d9f5d-dad3-482c-83d2-01781d5254bc"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7df949c5-515e-432b-8bdb-e9e5662d9390"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7e0f22c4-f658-4a88-a3cc-6f12c1c7ed9f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7ed4b5e6-7bdf-498d-b0f7-30697c42852d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7f2125f6-6ee2-4553-b460-4620ad851fa2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7f36b186-52f7-416b-88f6-d9fd1070ef65"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7f8e8cec-63bc-448d-a885-17fd5dc52f4f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7fe1b2dd-9d66-44d0-9ca1-81eb1677a760"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7fe7dc2e-fd2d-4f11-9eab-6f989fa28370"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("81db70dd-28d3-4b13-b3a8-e9bf0ad06164"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("81fac015-dfe8-47ed-9dc3-eb123c443df5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("822cd94b-efc8-4d42-9f08-e45a8c09ff08"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("835d04c3-55f1-48a3-9d08-238b154fadc5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("83cf40f3-989c-47ed-acca-ca8fc1a36dc6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("842053b6-3ef5-4b4a-9093-7617a1a3877b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("85abd5b1-e658-49e9-95d1-47697e99eece"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("862ec6d5-442f-4d36-ab1b-edb5d0810e4e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("86ae0cb5-9847-4e9d-b455-37cd6ce64432"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("87943431-5c41-4d3a-9ddb-27a2ef0437dc"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("87c44005-eb18-4666-8841-7e7a694cfdfb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("89376c1d-1be1-4a9f-b60b-03086c77ecfd"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8a02985d-25e5-44cc-aa67-5abc5c6b99ae"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8d5faa72-8e4b-4ada-a03c-01ee89b8842c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8fc844bf-3973-4859-9da8-6d845795dea2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("915cf1a2-34de-40e1-b2d1-565ecdc7ec57"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("91f7767f-44d2-462c-8819-0f02d8753f03"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("92aaed79-946f-4206-a626-e3f21a3981f2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("92e54d0a-5c53-47ce-8ee8-e7a0665ef35f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("97ed71c8-3608-4be9-bbfc-4ac4dc709a27"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("995b091c-84dd-4b62-9433-b44af2fa1dce"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("99a92139-5623-4ae6-b6c3-7b7a59aa3302"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9b0728c1-45b9-4213-ad1b-05964ddbcb75"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9b12b484-c272-4524-a9af-e55be2dbc403"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9bcd4ceb-e366-4f1a-ac01-65ac7f5dd2e7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9d9b4e06-117a-42ab-be04-8c5d0d8086e6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9f328dd8-889c-4e5b-bcaa-4c7667a12b04"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a02aee3c-ed66-44aa-ad42-50d5f03581ae"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a030cbca-f61c-45f8-9853-5ec01d0f9050"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a2c7f139-d1c7-409d-a2b2-eaddbfaddf8b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a32a1eb4-8c43-474a-95ea-a411218b629e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a3572d39-f308-4d98-8836-b295fbc510ea"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a58dba64-1c89-472a-98fd-e47ad93606d5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a5de500c-9c75-4d5f-ace2-bcc927005339"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a6b9c185-e1ba-4cad-80db-0a2856a157f5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a737f75a-66be-4ec1-bd1e-5700accc9e99"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a79c99ae-cb5f-439e-8d9c-e8b1ee7830a7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a924e6de-c8d0-4991-878d-552f3766dcc6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a9d04007-bbd2-49f5-a346-78a7903f5fb9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("aa68aab3-529a-4d30-aeff-2ddb2de5e328"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ab536b95-e77d-4ef0-b59e-b66437e9e97a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("abbdccdc-224e-4328-92ca-9b5c023fe994"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ac188a65-7f7b-4a11-b17e-2a409630b9d5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ac46aad0-807a-4ed6-8345-4e5569de01cc"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ad8590bf-1c93-45b3-8ec9-3fe4aa44d66b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("add6e0c3-718a-4e91-b402-1de1b13f4e7c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ae74ff95-9c32-4587-b856-d4c7ee07c3b0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("aed3f5bc-2900-4a97-bf59-cecc47762d4b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("af55b6c7-02db-4bb1-993c-5240f9e5f6b5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b12b0c1c-a214-4bc0-88a9-8ce74c171a4b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b3dd3a36-c538-4f19-85dd-ebaf59a2163d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b4257e9c-8eff-4d2e-9bbd-e9fa6c648d92"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b4b40c51-2dfc-4d7c-8e3e-5a1835e660f8"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b4b49e8a-398b-4f8f-8965-bb86465ac62c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b5fe06ee-4317-462b-85c8-c43d3caf6335"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b65b54d7-7ab4-4d5e-b735-b187e2bb4948"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b6a836f6-9b95-4990-9b87-a1aac258874e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b89c8414-8045-407a-83fc-5fa38e79a033"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("bddfa270-3358-48eb-8d48-0d1b99ddd2d5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("be98ba37-711c-4443-b953-7ed454e22994"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("be9ed0d7-07eb-44d1-9e10-4751d3b00670"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c0436899-d415-43cf-af7a-d8c94ca8cd4d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c29b1e8b-70e0-4dfa-85cb-4c66a6092a8b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c2cc620b-daa7-4c5c-893f-8ceedfb338fd"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c39d2f24-71a9-4c07-90b7-7b86550e3144"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c4686382-7560-4b03-8a77-fd96ccc7894e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c5f714ed-d3e8-4b24-8a09-eb1014280ad3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c901cdc6-608d-44dd-a7b1-e408cf5e19b2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("cd0db0e8-b416-4a83-a4ac-01e80abce93c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("cf19d18a-4624-4783-b313-7a0b9516388b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("cf4faca0-8d6a-4c8e-9c34-6c3877635402"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d033c31d-fd51-4e1f-a372-0c1c2d490e71"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d0da595c-992c-4b9f-9dde-ef9de2b887ca"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d0e8f678-0cd0-4955-a94a-1e660d63291d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d2c00d6e-ed25-40fd-9d5e-2bc81bb5cc5c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d37e6819-78ec-499b-a0c6-152028977241"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d4ae0f6b-e6b5-436a-b9c4-0ecfbe49dcbf"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d4e1a5a8-0773-4728-9174-95a8d0be75dc"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d6241117-115f-44e8-80a5-7e086eaafc44"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d64cb445-6272-4280-8bc7-c136d750cc3d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d92c440f-2328-4deb-b112-c676780be9cd"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d9ff1cd1-2325-46ed-a511-0b9265b351e6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("da70e2cf-8a08-4b8d-aad0-3069ad37c99c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("db7c846b-b88b-4198-bdba-ca531c7b6218"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dbc89496-36d5-4199-9aea-5c3b81bfa43e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dede716f-f41d-4ec7-bf49-e09e78fc2d07"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e4e51a00-2e2d-4140-93e4-ab1403aab020"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e56aadc5-f0f4-46f9-9ee2-1504a54b921d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e5aa22fa-7132-4891-a091-ac8fc74580da"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e6647cb2-8de2-475a-83b9-c62b3dbc1771"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e67ef067-8b18-4a58-9ab0-1273ac917add"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e68b539d-e0e4-414f-a078-779ff5aaf593"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e6b4db96-60b2-47aa-8e4e-fbf791cd423f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e7032f77-aa5a-4c12-98f0-e9c01bb690ea"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e778519c-bb72-4fb6-bd32-65b05b688b6a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e87fc1b4-b220-485d-a805-5c32aa0226c4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e89c85ef-0721-4549-91a2-686a6075b0c6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e934fd03-a7b4-4434-a998-889384a22ab1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e999ad2c-2f50-4c24-a1b6-cff5eb4b7947"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ebe480c0-4fd8-413a-80fd-f664e9052322"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ed55c592-4b62-4666-a933-797b93e9644b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ed7cca78-fc07-4ee3-a0c3-2cc74ca6f1b0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ee218bb2-556b-49b5-91f3-b3ea56545a97"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("eef97a48-489f-48b9-bf2a-781e46264bc4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f00619a1-4b97-4dfd-80a4-e80752d3b02f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f10d5699-9fe9-4c13-83b1-da3c2749f69c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f2119d83-2b58-48ee-9bbf-9624debcdd63"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f2b8c2bb-1b70-40ed-a8a4-4e868c79fc2b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f2dcf584-68f1-4d07-87a0-956757798867"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f6466de1-0d9e-4114-a0d0-89626e5bd4a8"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f7925e4b-07bf-483c-bcae-69dccb875a57"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f83083c6-4ebd-40e0-a75c-f23da264dc1e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fa61d13e-387b-4021-8fa2-cd1a0dd66dc7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("faa970e4-d68e-4e1d-b613-039a6007a829"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fac1d51d-7914-422b-9789-65f2e099e226"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fb3a1fbc-6ac1-46c4-a932-0de0fe5905a7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fb8c0f17-0014-45f2-8c16-826c1eff610d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fbeb5d1f-fedd-418c-8885-7d7bc2c9fbc8"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fcaef1b5-7716-4b0f-b575-4a79c7bf6197"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fcb3f4a4-80b3-4bbc-b423-2dbf528f959d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fe469279-003f-4a6b-bfdc-5b8af1be97a2"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("0ab7c0e4-3df8-48ce-b1fb-6eda07bfcbc1"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("1b4de829-24a5-4dfb-871e-0d158fd13c39"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("560ac9e1-67ad-4868-8167-6c95798d0984"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("5724ea9e-0908-4077-a551-2b46d6503272"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("5e42f2ef-4d54-4689-8e9a-d6467940c64b"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("676626d7-2eb4-480b-a126-d87a08f3a296"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("83d49648-7271-40a7-b6eb-34a2756b0383"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("94abc1b7-a5f2-4679-973b-0cce6acef187"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("99f4af86-22d9-42c4-97a7-619c76bf8ba6"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("b9f27592-73d7-4092-b23b-acb9a34e2cd5"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("bc76842c-16c2-4a2c-8501-4c373c93d798"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("e340b2ef-558f-4aff-ac1e-653c8ade0215"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("35c1b4f6-bb14-4f78-b884-12f92d953773"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("4a31bd56-56f6-42b9-8336-615d7a4028a9"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("52c75e8a-11e3-43f0-a183-a6cad6fb9447"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("ab36a8f0-1579-4182-8632-eb405e52396b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0581fa51-e818-4a13-a562-6b0c44f2f472"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0f23b092-5697-48a7-a1fd-27a319891ade"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("132ded0b-6ab0-4378-91c3-9cbda3df0a79"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1bafc8ef-4e6b-48a9-aeb7-a03d9b6c9459"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1c70cb31-d36a-4d91-8335-565d7b8c3b89"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1dbdd880-d560-4366-a6ea-56bcc1033892"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1e39435a-af64-464e-847e-c40f13b02be7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("241fbd0e-40e1-4b94-b4c8-89f3a2acd326"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("255caacf-71fb-44a2-a0e4-6b972730f11c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2a1d0b21-39fd-46c8-8cd9-fd4e2c54f56d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2cdc5f29-ee79-4874-9fe6-6c9b0160a67b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("32beeaeb-5350-4b48-96bf-9355cff7182f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("32d7e113-4bd5-4cf1-92f4-ca09e3992980"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3d44594f-a842-4c7b-a126-e155c73ebd4d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4453850a-c98c-47c6-bb90-a23f05d74068"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("44c40fd8-6973-4765-aa14-bc314290f95f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("47f8214c-e054-40c7-82f7-16bc584f01c0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4b22effa-7f08-4ce7-a1df-307765201381"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4ccc837e-5d73-4f2a-b772-38a32a0ec654"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4fc79f2e-888a-4f4f-86bd-48a269d9128a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("53feccb3-ba48-4119-9aff-1d48fe51d930"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("55daa53f-5d63-46fa-9b0e-9a4a875118f8"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("578047e5-3e0d-4237-bc3f-a3ed369f154c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("60612d74-e879-4ae1-b5ab-4e28d01d996f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("61ab6c60-cdbb-47dc-95d3-85b3f66eed8d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("63e7f41a-82c8-4694-ab02-4985d38dddaf"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6a061105-0d86-48e0-8386-538abded095e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6c5edfee-23f4-4ab1-9c31-0312f9fde64d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("762e634d-9ab0-40c9-92df-d9f2576ed97f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7dd3668a-c7a5-4a3a-9891-770288e14912"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8f4591c1-f06a-4329-8aec-330a4fa2b390"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("96276c9d-8ea3-4a8e-9140-b912a87a002e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("96ef8e5a-31d6-4ff9-a1d5-9a72b22c7315"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9917a54c-6e9c-4a69-b081-8314d6c861b4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9d9ed3ab-7369-42d2-9064-f2cfaa61a6e0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a5cf346c-0a98-416e-b40d-f2dfa864f81e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b0397bd9-eb17-45b0-bb08-f59d92813500"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b1687b6a-b7f8-418d-bbc1-aff264d9e51b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b5883c28-6f1c-4b7d-ba8e-8a5b54ee8155"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("baeb278f-ec64-4f0f-a929-f43d3e44defd"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("bbef4379-4d5d-418f-8db6-891c578e1974"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("be47738a-43f3-43f5-8b9d-dd220dea79a7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c121c7c1-5012-40df-8a92-1d953dadba1a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ce5184b3-9f69-4a99-84c3-119b2f5b55e0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d1f857d5-4c78-4930-a0f7-a4dc281a642d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d2c08039-9ca0-4fe3-979a-97389232f138"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d39f9218-506f-4517-b9ec-41180f3aafd3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d47a77bb-59c7-486e-ad34-6ce1c3748a48"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d4c0d33c-8a72-47d4-aa72-e858ef3dce0c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dbdc410b-492c-48d6-9798-0646eef56f02"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc7307c8-e40d-4caa-9a73-3a26a28d085a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("de981b9b-da31-4ff5-84a9-4d0e52a33040"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e185926f-c9b1-4da2-906d-5d4a87ff36d9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e631ee84-ca3e-4bf6-93ee-2d98afefdadd"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ecefcba0-7ad4-4bfc-bb78-11130336e8a0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fbafda9d-ba58-466a-8eaf-87dd25e06037"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("04c64b79-bb52-4b4c-818d-0bd9ab0f3c2e"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("0ac78fcb-682e-4e70-975b-b428eab1b50d"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("15409f18-cf11-46b6-a4d1-93d20df98aa2"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("28baa537-fdb5-4769-b6c4-58ed09d0483b"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("4c0956b3-412d-4323-9b95-02bbfa00406e"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("4fafb0d7-5515-4e40-b7ff-1c20963b9e80"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("5299cb43-fb99-4d12-b23e-4ecc7d2e1da7"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("53c59ca4-7fe5-454d-abc8-5918c50e5bd5"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("5b14d294-dd3d-4b1e-bbfa-7ad247ffc5fc"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("5c83ac85-e0eb-4641-a091-0a9588c6c6b7"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("5dff48b3-13a5-4fc2-8ec3-e77e1b916413"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("6074c44a-efb0-47e0-81ba-ff7a2e4aced4"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("63c76e17-8fd3-4a42-8da6-51c90b72d629"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("6a75626c-4f42-4f4d-aba8-f9c50976a9e1"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("6b4a4884-68f0-4d20-b3dc-fe0f315a6ff7"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("761ad50c-3dcd-4dcf-b499-7a340cf99018"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("7671b037-bcbe-4f03-9327-0558a45cac97"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("81854fd5-c210-4661-9bb4-7430c4232c09"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("84e2ce26-b23b-40e8-98cd-ba1ffa2393cc"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("84fe3332-8aa4-4f4f-8e2c-fb8d7b89c390"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("988566a2-ff57-433c-bdfa-606759b6a1fa"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("9a92b988-746c-4920-b05e-78e9eed61bfc"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("9ac2708b-377a-4f18-a67f-aa34a57700c2"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("b563e880-5079-488e-8020-6b12038c2aa3"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("bfd7adaa-71aa-4ea5-8ddd-a716a8407fa3"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("da613513-c07e-4d60-b598-7dc7bf446a85"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("dbc9cbef-ea4e-4b96-9229-94326fca9a5e"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("e0787012-fc25-4fc7-95fb-74d8760e2061"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("ed21cfda-2730-45e2-9f7c-dd483cb3d25c"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("f1530d50-bfb6-478b-b5c8-0ea238fcccd5"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("f313499e-588f-44b3-ba24-a1cae87d9ff1"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("fefe5c38-f73a-4196-818b-810daaa7f4aa"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5fc13ff-3cbd-4a0c-b400-6badf1d54263"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a38028e-8886-49e7-ab6a-f613ec71c67d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44e01935-6329-4a00-a0ed-bbea8fcdfe27"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("2ba8fe74-4bf6-4a35-8922-96754001d7df"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("e2063825-51ae-4d21-bb99-542127c58054"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("fcd81c78-9863-4dc0-ad4d-8148fe7cfc60"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8e932dbf-d4b6-43f5-aff3-af6684655e79"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("2e911361-796a-4742-a451-07c0852c7db9"));

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId", "RpeSystem", "Theme", "UnitSystem" },
                values: new object[] { new Guid("b80a4b22-8bb7-4d92-818f-b43bbe8bc480"), new Guid("7a47e970-7677-4cc1-9a0d-9d8992d1c777"), "Rpe", "Light", "Imperial" });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId", "RpeSystem", "Theme", "UnitSystem" },
                values: new object[] { new Guid("c1962484-4bea-45cd-990e-4fe39ec4fd45"), new Guid("fdd5335d-8fa5-4d10-8435-d4aec7b6245a"), "Rpe", "Light", "Imperial" });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId", "RpeSystem", "Theme", "UnitSystem" },
                values: new object[] { new Guid("1e7f2ca5-c111-471e-9dbb-101a55f34d01"), new Guid("86c2222f-d07d-4540-a667-fbb663aac40b"), "Rpe", "Light", "Imperial" });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId", "RpeSystem", "Theme", "UnitSystem" },
                values: new object[] { new Guid("89334edd-5b93-454f-8a68-a8d207943048"), new Guid("a1d5017b-0d2c-4c91-8a6e-6ccebe987442"), "Rpe", "Light", "Imperial" });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("247ed77d-5598-4825-be8e-53b516ceed8a"), "TrainingCreated", new Guid("b80a4b22-8bb7-4d92-818f-b43bbe8bc480") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("0cc23d87-529f-42e4-b0a0-e9bfb07f75fa"), "NoteAdded", new Guid("b80a4b22-8bb7-4d92-818f-b43bbe8bc480") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("ee5186a2-6c22-4716-b0dc-2e7449153c36"), "MediaAdded", new Guid("b80a4b22-8bb7-4d92-818f-b43bbe8bc480") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("63a59103-8213-49b4-b041-f53cf433a97e"), "TrainingCreated", new Guid("c1962484-4bea-45cd-990e-4fe39ec4fd45") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("913130b2-8a6d-42f2-b447-f536c7d2a117"), "NoteAdded", new Guid("c1962484-4bea-45cd-990e-4fe39ec4fd45") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("28ef3559-2ca2-47a9-933f-8492421aa25c"), "MediaAdded", new Guid("c1962484-4bea-45cd-990e-4fe39ec4fd45") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("fb8b2a28-7535-4396-a472-2fa7cfc38901"), "TrainingCreated", new Guid("1e7f2ca5-c111-471e-9dbb-101a55f34d01") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("c534ee5d-085f-4738-8870-a1e95b7c1bd8"), "NoteAdded", new Guid("1e7f2ca5-c111-471e-9dbb-101a55f34d01") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("0b075622-ad21-4dec-a3a2-db9d2e34f15a"), "MediaAdded", new Guid("1e7f2ca5-c111-471e-9dbb-101a55f34d01") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("9664b679-f797-44f6-9e22-42aadb1a67ce"), "TrainingCreated", new Guid("89334edd-5b93-454f-8a68-a8d207943048") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("3bf74098-ded5-44bf-9dfe-d5c8898c37bc"), "NoteAdded", new Guid("89334edd-5b93-454f-8a68-a8d207943048") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("5bc9c3e8-36be-4873-be0a-1c9148fb230f"), "MediaAdded", new Guid("89334edd-5b93-454f-8a68-a8d207943048") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "Gender", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[] { new Guid("7a47e970-7677-4cc1-9a0d-9d8992d1c777"), "User", null, new DateTime(2019, 11, 14, 22, 46, 8, 499, DateTimeKind.Utc).AddTicks(5776), "cus_FLi7gZv8w0j0GB", "admin@trainingcompanion.com", "Admin", "Male", "", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", new Guid("b80a4b22-8bb7-4d92-818f-b43bbe8bc480"), "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "Gender", "LastName", "PasswordHash", "UserSettingId", "Username", "CoachId" },
                values: new object[] { new Guid("fdd5335d-8fa5-4d10-8435-d4aec7b6245a"), "User", null, new DateTime(2019, 11, 14, 22, 46, 8, 500, DateTimeKind.Utc).AddTicks(2341), null, "athlete@trainingcompanion.com", "Athlete", "Male", "", "23a1f74bc589fe525387f8d2c40f1e552a564fe5de00af935bb7a0592fc976c6", new Guid("c1962484-4bea-45cd-990e-4fe39ec4fd45"), "athlete", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "Gender", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[] { new Guid("86c2222f-d07d-4540-a667-fbb663aac40b"), "User", null, new DateTime(2019, 11, 14, 22, 46, 8, 500, DateTimeKind.Utc).AddTicks(7999), "cus_FHk5RepADdfm5H", "coach@trainingcompanion.com", "Coach", "Male", "", "e0f167bc84b881bc06f6884fb48e02f41dfc5579e25489db6c6bde238e4aed15", new Guid("1e7f2ca5-c111-471e-9dbb-101a55f34d01"), "coach" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "Gender", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[] { new Guid("a1d5017b-0d2c-4c91-8a6e-6ccebe987442"), "User", null, new DateTime(2019, 11, 14, 22, 46, 8, 500, DateTimeKind.Utc).AddTicks(3496), null, "solo.athlete@trainingcompanion.com", "Solo", "Male", "Athlete", "304301ea5935cd1d38e55206e09eebcfe95fcb56f96ddf0ef2d8557a295728c8", new Guid("89334edd-5b93-454f-8a68-a8d207943048"), "soloathlete" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("c0a0b90d-1ea8-47a5-9f90-6de9aafbf1d0"), new Guid("7a47e970-7677-4cc1-9a0d-9d8992d1c777"), "Squat - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("a267affa-2fc7-4085-a6aa-daa4f531ece0"), new Guid("86c2222f-d07d-4540-a667-fbb663aac40b"), "Squat - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("45e822b7-335c-4b5a-be13-5d5d2d84c8a2"), new Guid("a1d5017b-0d2c-4c91-8a6e-6ccebe987442"), "Squat - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("dc4de66d-1ebf-43df-8d51-e531699fdc63"), new Guid("fdd5335d-8fa5-4d10-8435-d4aec7b6245a"), "Deadlift - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("26ba685a-9543-4d14-a848-77dc5e741761"), new Guid("86c2222f-d07d-4540-a667-fbb663aac40b"), "Bench press - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("2ade937e-231c-4fc6-b48b-31bf7773e8a3"), new Guid("fdd5335d-8fa5-4d10-8435-d4aec7b6245a"), "Squat - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("638442e6-29b8-458f-a9a9-414186565efc"), new Guid("a1d5017b-0d2c-4c91-8a6e-6ccebe987442"), "Bench press - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("4ceb30ac-cac8-48cb-9d36-ce87376e8fcb"), new Guid("a1d5017b-0d2c-4c91-8a6e-6ccebe987442"), "Deadlift - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("e5774f97-bacd-419a-852c-7f393f0984a9"), new Guid("fdd5335d-8fa5-4d10-8435-d4aec7b6245a"), "Bench press - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("90f54812-230e-4fbd-bbdd-7b545456a768"), new Guid("86c2222f-d07d-4540-a667-fbb663aac40b"), "Deadlift - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("0d9483cb-bbde-44af-ad7f-ca94a99399f5"), new Guid("7a47e970-7677-4cc1-9a0d-9d8992d1c777"), "Bench press - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("b294185e-360f-4169-b7f0-726a84401812"), new Guid("7a47e970-7677-4cc1-9a0d-9d8992d1c777"), "Deadlift - competition" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("be71df7d-c2c4-4d8c-a60b-fb67e796c3c9"), new Guid("86c2222f-d07d-4540-a667-fbb663aac40b"), 1, "Bar type" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("95a7b872-00f3-4149-adf9-ee0f17d7e874"), new Guid("86c2222f-d07d-4540-a667-fbb663aac40b"), 2, "Bar position" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("1a44432c-d38b-4fae-a8ac-95802c1daf4b"), new Guid("86c2222f-d07d-4540-a667-fbb663aac40b"), 3, "Equipment" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("9beeab16-2874-4812-8ced-eac882ab9929"), new Guid("86c2222f-d07d-4540-a667-fbb663aac40b"), 4, "Grip" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("db54c1de-a14f-45a2-8541-044d5b94875f"), new Guid("86c2222f-d07d-4540-a667-fbb663aac40b"), 5, "Range of motion" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("9c94475f-005a-4a1b-bb78-8d0e46aec6d6"), new Guid("86c2222f-d07d-4540-a667-fbb663aac40b"), 6, "Stance" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("ddffdd09-9671-43df-bc8e-d0ae682edfa8"), new Guid("86c2222f-d07d-4540-a667-fbb663aac40b"), 7, "Tempo" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("b2a730a9-f9ec-49ef-ac19-7277a31cb9ab"), new Guid("86c2222f-d07d-4540-a667-fbb663aac40b"), 8, "Load accommodation" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("99cb0e16-1d71-436f-b717-8508e3127f73"), new Guid("a1d5017b-0d2c-4c91-8a6e-6ccebe987442"), 6, "Stance" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("b645ef34-dc6f-4c6f-be58-6f65b13871f1"), new Guid("a1d5017b-0d2c-4c91-8a6e-6ccebe987442"), 5, "Range of motion" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("4b229974-132b-45c1-9e04-b2ad3d20a31b"), new Guid("a1d5017b-0d2c-4c91-8a6e-6ccebe987442"), 4, "Grip" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("13d5960c-2a43-447a-a628-760246cdf4fe"), new Guid("a1d5017b-0d2c-4c91-8a6e-6ccebe987442"), 3, "Equipment" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("c43f4f29-0a49-4855-80c8-ae096714da79"), new Guid("a1d5017b-0d2c-4c91-8a6e-6ccebe987442"), 2, "Bar position" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("d4c3849f-d45c-4898-b660-c3598d3def6e"), new Guid("a1d5017b-0d2c-4c91-8a6e-6ccebe987442"), 1, "Bar type" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("327ae4f1-9ecd-49dc-a92e-bd71b4ac9694"), new Guid("a1d5017b-0d2c-4c91-8a6e-6ccebe987442"), 0, "Category" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("ba78b0b6-b632-403b-b96f-46bc5d025846"), new Guid("fdd5335d-8fa5-4d10-8435-d4aec7b6245a"), 8, "Load accommodation" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("ae080daf-0a36-435a-995d-ea04bd417270"), new Guid("a1d5017b-0d2c-4c91-8a6e-6ccebe987442"), 7, "Tempo" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("cf171282-137c-41f4-b732-1cc9e47886b7"), new Guid("7a47e970-7677-4cc1-9a0d-9d8992d1c777"), 0, "Category" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("1414296b-7d93-4f32-a161-65bfeb0b1028"), new Guid("7a47e970-7677-4cc1-9a0d-9d8992d1c777"), 1, "Bar type" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("b3b93ea3-ecc5-49fb-a7cf-54ff1f32ea4f"), new Guid("7a47e970-7677-4cc1-9a0d-9d8992d1c777"), 2, "Bar position" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("492edf8c-f9d9-460d-8dbe-5c7c5425bf98"), new Guid("7a47e970-7677-4cc1-9a0d-9d8992d1c777"), 3, "Equipment" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("8dac575b-0298-455c-a62d-5e04badebc57"), new Guid("7a47e970-7677-4cc1-9a0d-9d8992d1c777"), 4, "Grip" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("27606fc6-b45e-4c4d-a211-5b26eb59fee3"), new Guid("7a47e970-7677-4cc1-9a0d-9d8992d1c777"), 5, "Range of motion" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("23c04279-a46d-4ac7-8bb0-40579e43b754"), new Guid("7a47e970-7677-4cc1-9a0d-9d8992d1c777"), 6, "Stance" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("8c96b12b-5fe3-4b15-a271-e26c51da3b02"), new Guid("7a47e970-7677-4cc1-9a0d-9d8992d1c777"), 7, "Tempo" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("b54fddef-a30d-4afd-b526-d47091aa69d7"), new Guid("7a47e970-7677-4cc1-9a0d-9d8992d1c777"), 8, "Load accommodation" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("a213c566-a91a-4cbf-8c01-871c27390d35"), new Guid("fdd5335d-8fa5-4d10-8435-d4aec7b6245a"), 0, "Category" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("fa93c83f-a4fc-4c13-81bf-117dd6a5de50"), new Guid("fdd5335d-8fa5-4d10-8435-d4aec7b6245a"), 1, "Bar type" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("71a99dac-b986-4d92-84e1-715ae1c4aa54"), new Guid("fdd5335d-8fa5-4d10-8435-d4aec7b6245a"), 2, "Bar position" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("083fbf61-4b06-4e58-892f-48b325563e03"), new Guid("fdd5335d-8fa5-4d10-8435-d4aec7b6245a"), 3, "Equipment" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("460af3c6-b087-4c43-b612-3b540573d95c"), new Guid("fdd5335d-8fa5-4d10-8435-d4aec7b6245a"), 4, "Grip" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("2637c1da-cd98-4225-a084-0fdc7b3aba4e"), new Guid("fdd5335d-8fa5-4d10-8435-d4aec7b6245a"), 5, "Range of motion" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("9fdb912b-fac9-49be-8f8b-17172e9a2c85"), new Guid("fdd5335d-8fa5-4d10-8435-d4aec7b6245a"), 6, "Stance" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("a5f0726a-1f75-4995-a2cb-dbfc4ceeee52"), new Guid("fdd5335d-8fa5-4d10-8435-d4aec7b6245a"), 7, "Tempo" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("680c3314-0ac4-4275-8170-b4a1b73d0b86"), new Guid("86c2222f-d07d-4540-a667-fbb663aac40b"), 0, "Category" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("5470d9fb-c969-45aa-81f2-5d4f9d63e609"), new Guid("a1d5017b-0d2c-4c91-8a6e-6ccebe987442"), 8, "Load accommodation" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("22f1365e-3b8e-4e85-bfaf-f7a3f337d209"), 0, new Guid("cf171282-137c-41f4-b732-1cc9e47886b7"), "Knee dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7f6d3908-b870-43f5-947b-ab8e4e2f5d44"), 5, new Guid("db54c1de-a14f-45a2-8541-044d5b94875f"), "High pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2ae2aedf-4898-49de-a4f7-2ea012a22a2e"), 6, new Guid("db54c1de-a14f-45a2-8541-044d5b94875f"), "Two inch deficit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("27908afc-facb-4f29-878b-63188773c135"), 7, new Guid("db54c1de-a14f-45a2-8541-044d5b94875f"), "Half board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e3f31d73-cf41-4fd8-9cc6-2169ab38c8ac"), 8, new Guid("db54c1de-a14f-45a2-8541-044d5b94875f"), "Two board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bbd084f7-027a-4e4b-ba12-f56b57d1ab39"), 9, new Guid("db54c1de-a14f-45a2-8541-044d5b94875f"), "Three board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5d5a2ca1-381a-4df9-92ab-d654e0c11142"), 10, new Guid("db54c1de-a14f-45a2-8541-044d5b94875f"), "Four board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8247a1b5-862d-438b-8313-7b93cb97a183"), 11, new Guid("db54c1de-a14f-45a2-8541-044d5b94875f"), "Five board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8d9ee36e-f606-4c38-a761-d885e010ad0b"), 12, new Guid("db54c1de-a14f-45a2-8541-044d5b94875f"), "Towel - 8 cm " });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7e3dcfd7-14bb-435a-bb0a-e32915ed24bd"), 0, new Guid("9c94475f-005a-4a1b-bb78-8d0e46aec6d6"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("604c712f-7d61-4702-9c3f-9f781164d08a"), 1, new Guid("9c94475f-005a-4a1b-bb78-8d0e46aec6d6"), "Narrow" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9a054962-ebc1-45de-ac41-fcf843ef6e6e"), 2, new Guid("9c94475f-005a-4a1b-bb78-8d0e46aec6d6"), "Wide" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("daea1511-4213-4dfd-849d-d7fc846b5f0e"), 3, new Guid("9c94475f-005a-4a1b-bb78-8d0e46aec6d6"), "Sumo" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("18a500f4-c8b3-4ae8-be11-c8756b5c910f"), 4, new Guid("9c94475f-005a-4a1b-bb78-8d0e46aec6d6"), "Conventional" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("856ad28b-1156-4b93-80aa-7967e73fc6bf"), 5, new Guid("9c94475f-005a-4a1b-bb78-8d0e46aec6d6"), "Stiff legged" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("de9a955b-f608-4301-8400-b653690d4ffe"), 6, new Guid("9c94475f-005a-4a1b-bb78-8d0e46aec6d6"), "Feet up" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f86f21d4-75ed-428e-a460-d8c23ad05e86"), 0, new Guid("ddffdd09-9671-43df-bc8e-d0ae682edfa8"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d41c546c-a285-44af-8a72-f9c02547d7a3"), 1, new Guid("ddffdd09-9671-43df-bc8e-d0ae682edfa8"), "Touch and go" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3dc04d3e-80bc-475e-bb48-3fc0625fda3e"), 4, new Guid("b2a730a9-f9ec-49ef-ac19-7277a31cb9ab"), "Reverse light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bcaa6977-6b2c-460c-9533-1f64a4ac7b65"), 3, new Guid("b2a730a9-f9ec-49ef-ac19-7277a31cb9ab"), "Chains" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7d8ad7d0-a6f5-4ee0-8be2-7c02cc45cf77"), 2, new Guid("b2a730a9-f9ec-49ef-ac19-7277a31cb9ab"), "Strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ba4ecd85-c022-4a18-8938-1811b2bad598"), 1, new Guid("b2a730a9-f9ec-49ef-ac19-7277a31cb9ab"), "Average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("015624f3-3ddc-4bc3-8df7-e12b8e9050a2"), 0, new Guid("b2a730a9-f9ec-49ef-ac19-7277a31cb9ab"), "Light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("949fd6ac-95f7-4051-a58f-09206320d959"), 10, new Guid("ddffdd09-9671-43df-bc8e-d0ae682edfa8"), "Tempo - 003" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("985bebeb-fc4e-4da7-8521-02e2e651dfe4"), 4, new Guid("db54c1de-a14f-45a2-8541-044d5b94875f"), "Middle pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("df2adb65-dae8-4058-9226-ea91d510a0d4"), 9, new Guid("ddffdd09-9671-43df-bc8e-d0ae682edfa8"), "Tempo - 303" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fbd0706f-d550-41ae-93b1-ae44456d7f53"), 7, new Guid("ddffdd09-9671-43df-bc8e-d0ae682edfa8"), "Tempo - 320" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("af8ea610-f52f-4cd4-84ae-be5615e25675"), 6, new Guid("ddffdd09-9671-43df-bc8e-d0ae682edfa8"), "Tempo - 600" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9a4a48e7-a52c-457e-9f9e-189c6d0beaea"), 5, new Guid("ddffdd09-9671-43df-bc8e-d0ae682edfa8"), "Pause - 7 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0e56dc17-77e7-4be1-8f7a-76ad0fc53d6b"), 4, new Guid("ddffdd09-9671-43df-bc8e-d0ae682edfa8"), "Pause - 5 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("92982ead-15d8-42b5-9a3d-87a1b9820c5a"), 3, new Guid("ddffdd09-9671-43df-bc8e-d0ae682edfa8"), "Pause - 3 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ce647eeb-fe8d-426c-9087-f5a74907234b"), 2, new Guid("ddffdd09-9671-43df-bc8e-d0ae682edfa8"), "Pause - 2 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("feb620b1-5b6b-403f-b76d-1212cb19fb58"), 8, new Guid("ddffdd09-9671-43df-bc8e-d0ae682edfa8"), "Tempo - 530" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("457017bb-9624-4e74-8e7b-b995a228c0bb"), 5, new Guid("b2a730a9-f9ec-49ef-ac19-7277a31cb9ab"), "Reverse average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bb69e608-f96f-4193-97c9-e29b3260d18d"), 3, new Guid("db54c1de-a14f-45a2-8541-044d5b94875f"), "Low pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b55692ba-04bb-4698-a68b-8915c946bc3a"), 1, new Guid("db54c1de-a14f-45a2-8541-044d5b94875f"), "Box" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("18b49b52-c923-454d-bbc1-a128ee7ac366"), 2, new Guid("680c3314-0ac4-4275-8170-b4a1b73d0b86"), "Horizontal push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("53af3302-65c5-4857-a00c-41c960524ac2"), 3, new Guid("680c3314-0ac4-4275-8170-b4a1b73d0b86"), "Horizontal pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0d4a4248-5ce5-4ab8-a0ec-4c603972b2d4"), 4, new Guid("680c3314-0ac4-4275-8170-b4a1b73d0b86"), "Vertical push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("349f5e1b-ddfd-4213-bc46-da94868163de"), 5, new Guid("680c3314-0ac4-4275-8170-b4a1b73d0b86"), "Vertical pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1f787679-18bb-4775-8896-699360cb8aad"), 6, new Guid("680c3314-0ac4-4275-8170-b4a1b73d0b86"), "Other" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("136de81c-3aa6-4d71-aa2a-16ecc2e0712a"), 0, new Guid("be71df7d-c2c4-4d8c-a60b-fb67e796c3c9"), "Barbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3af36a66-b744-4935-8cb0-4541432b1e27"), 1, new Guid("be71df7d-c2c4-4d8c-a60b-fb67e796c3c9"), "Dumbbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("cd555634-f5bb-4fdd-b4b0-77948ab841e1"), 2, new Guid("be71df7d-c2c4-4d8c-a60b-fb67e796c3c9"), "Saftey bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("38c8e07f-874d-4953-9e04-be4acf3aa080"), 3, new Guid("be71df7d-c2c4-4d8c-a60b-fb67e796c3c9"), "Cambered bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("03f81890-e1f1-4a8c-8f8b-705f56d1ed57"), 4, new Guid("be71df7d-c2c4-4d8c-a60b-fb67e796c3c9"), "Neutral-grip bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("26ef65f4-d8bd-4792-bf41-d89e99daeb6d"), 5, new Guid("be71df7d-c2c4-4d8c-a60b-fb67e796c3c9"), "Trap bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0ff46d56-eee8-4bb9-9d21-6cc12c890b84"), 6, new Guid("be71df7d-c2c4-4d8c-a60b-fb67e796c3c9"), "Buffalo bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("14185fc6-ec2a-4690-8a59-7ed54098c33f"), 7, new Guid("be71df7d-c2c4-4d8c-a60b-fb67e796c3c9"), "Machine" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("58d513d4-0e65-4f16-a37b-71d581b7da80"), 0, new Guid("95a7b872-00f3-4149-adf9-ee0f17d7e874"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bbbfbecb-2449-4487-a5a7-d923b3c630f5"), 1, new Guid("95a7b872-00f3-4149-adf9-ee0f17d7e874"), "High bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("74de7c7f-b9b3-4cac-beb0-4184deb56848"), 2, new Guid("95a7b872-00f3-4149-adf9-ee0f17d7e874"), "Low bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("25ec903c-c75d-42bd-9f6b-c60e8f357bca"), 3, new Guid("95a7b872-00f3-4149-adf9-ee0f17d7e874"), "Front rack" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9dbdd344-17b6-4a50-b224-724be130617d"), 0, new Guid("db54c1de-a14f-45a2-8541-044d5b94875f"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("899e9e38-13c4-41cb-af9d-9dfc98b8e6e8"), 3, new Guid("9beeab16-2874-4812-8ced-eac882ab9929"), "Wide grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("295d2b61-14e2-495a-b2b3-553478fee15a"), 2, new Guid("9beeab16-2874-4812-8ced-eac882ab9929"), "Close grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a091cf6a-d4a2-4d29-ab42-c241aa8cedc0"), 1, new Guid("9beeab16-2874-4812-8ced-eac882ab9929"), "Reverse grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d022377f-7bbc-430d-a9c2-96d680b8ce65"), 0, new Guid("9beeab16-2874-4812-8ced-eac882ab9929"), "Snatch grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e7672caa-511d-49df-b856-1b9085126fd6"), 7, new Guid("1a44432c-d38b-4fae-a8ac-95802c1daf4b"), "Wrist wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("32942bdd-2c15-4692-81eb-36b14a4ae858"), 2, new Guid("db54c1de-a14f-45a2-8541-044d5b94875f"), "Towel" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3ed6ac73-31be-4239-ba1e-e6a5259623e4"), 7, new Guid("1a44432c-d38b-4fae-a8ac-95802c1daf4b"), "Deadlift suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("861d292b-a1a8-4ccf-93f6-cdbf55f6f88e"), 5, new Guid("1a44432c-d38b-4fae-a8ac-95802c1daf4b"), "Squat suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("121b3d46-6e3a-437f-a72f-3040ad26e4dc"), 4, new Guid("1a44432c-d38b-4fae-a8ac-95802c1daf4b"), "Breifs" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5df1f9f9-ac06-4ccc-a84c-65c8a25acea2"), 3, new Guid("1a44432c-d38b-4fae-a8ac-95802c1daf4b"), "Slingshot" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3094e40a-75c0-4368-9e59-64bd43130f44"), 2, new Guid("1a44432c-d38b-4fae-a8ac-95802c1daf4b"), "Knee wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("51eea30e-56e0-45cb-a2f2-37511fc4bbf7"), 1, new Guid("1a44432c-d38b-4fae-a8ac-95802c1daf4b"), "Knee sleeves" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a73d798f-1d41-4bba-9e50-7efdb41970bf"), 0, new Guid("1a44432c-d38b-4fae-a8ac-95802c1daf4b"), "Belt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b8428655-21b8-4f93-a26c-72ddaf8b0a7f"), 6, new Guid("1a44432c-d38b-4fae-a8ac-95802c1daf4b"), "Bench shirt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9235ae68-04bf-487a-aff1-95f194145bb0"), 1, new Guid("680c3314-0ac4-4275-8170-b4a1b73d0b86"), "Hip dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fb74dcbd-4ce4-4ed2-8abb-d92ab657d41a"), 6, new Guid("b2a730a9-f9ec-49ef-ac19-7277a31cb9ab"), "Reverse strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("86cc5bdf-179f-40ab-8d62-5d96bca006d6"), 1, new Guid("327ae4f1-9ecd-49dc-a92e-bd71b4ac9694"), "Hip dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("dd07b0ae-74cf-42e8-9ec8-4a8cf59de3f0"), 5, new Guid("b645ef34-dc6f-4c6f-be58-6f65b13871f1"), "High pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("02a4a3d7-48f9-46b6-a865-1b80350b758a"), 6, new Guid("b645ef34-dc6f-4c6f-be58-6f65b13871f1"), "Two inch deficit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ff57ee13-0a8b-4d77-a58e-b3b441f11fbd"), 7, new Guid("b645ef34-dc6f-4c6f-be58-6f65b13871f1"), "Half board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("de9f6bf1-a7bd-479c-89d2-c9b8c7b5862d"), 8, new Guid("b645ef34-dc6f-4c6f-be58-6f65b13871f1"), "Two board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9ce93468-6a4a-450e-acfa-b498b5e7e2f1"), 9, new Guid("b645ef34-dc6f-4c6f-be58-6f65b13871f1"), "Three board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c60f1028-8a01-459a-92a5-e1df0a77c1e2"), 10, new Guid("b645ef34-dc6f-4c6f-be58-6f65b13871f1"), "Four board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2ab73885-4165-44ef-97e7-6048f1c10c02"), 11, new Guid("b645ef34-dc6f-4c6f-be58-6f65b13871f1"), "Five board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("743e7328-c55e-41b9-a029-50c1cc5b272b"), 12, new Guid("b645ef34-dc6f-4c6f-be58-6f65b13871f1"), "Towel - 8 cm " });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1301b30f-4ae0-4574-ae5e-69a94a9b0de1"), 0, new Guid("99cb0e16-1d71-436f-b717-8508e3127f73"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d7b55bfd-66ee-4a73-ab48-697b3f907e7e"), 1, new Guid("99cb0e16-1d71-436f-b717-8508e3127f73"), "Narrow" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6c9d64b0-d0a3-42e1-ba24-6941f5a6988b"), 2, new Guid("99cb0e16-1d71-436f-b717-8508e3127f73"), "Wide" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1046e8bc-6241-438a-8b67-8983d471518b"), 3, new Guid("99cb0e16-1d71-436f-b717-8508e3127f73"), "Sumo" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c66a0aee-7ef2-4292-a0e2-a7e53d893289"), 4, new Guid("99cb0e16-1d71-436f-b717-8508e3127f73"), "Conventional" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6c3fba0a-276c-48a6-ac24-364d9c2d972e"), 5, new Guid("99cb0e16-1d71-436f-b717-8508e3127f73"), "Stiff legged" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("24d4349a-a2c5-484a-b442-32be0734ccee"), 6, new Guid("99cb0e16-1d71-436f-b717-8508e3127f73"), "Feet up" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("64a4326a-5de2-4c3a-8e60-02a95a3c64f4"), 0, new Guid("ae080daf-0a36-435a-995d-ea04bd417270"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a5d4d984-47c7-4b64-8844-17bea46d0414"), 1, new Guid("ae080daf-0a36-435a-995d-ea04bd417270"), "Touch and go" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6a79b0ac-0113-4fec-a1fc-3d7741e672a6"), 4, new Guid("5470d9fb-c969-45aa-81f2-5d4f9d63e609"), "Reverse light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("33ca6a14-0572-4a5f-9b5f-e65f6c705517"), 3, new Guid("5470d9fb-c969-45aa-81f2-5d4f9d63e609"), "Chains" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e3bc8b5f-abbe-452e-93eb-b2cb3bfea81f"), 2, new Guid("5470d9fb-c969-45aa-81f2-5d4f9d63e609"), "Strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a5b92710-2215-4af6-9f84-c9f4e8662a05"), 1, new Guid("5470d9fb-c969-45aa-81f2-5d4f9d63e609"), "Average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3e5ed709-8423-48c1-95bf-ed62eb08405d"), 0, new Guid("5470d9fb-c969-45aa-81f2-5d4f9d63e609"), "Light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b5541853-a456-47ff-bba1-f51c43dc3517"), 10, new Guid("ae080daf-0a36-435a-995d-ea04bd417270"), "Tempo - 003" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("cb15132e-0b65-4b7b-ab30-708c1d6b1199"), 4, new Guid("b645ef34-dc6f-4c6f-be58-6f65b13871f1"), "Middle pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d65c53b8-9e14-4154-8e33-63691149fe46"), 9, new Guid("ae080daf-0a36-435a-995d-ea04bd417270"), "Tempo - 303" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8c718945-c982-48ec-908b-b91d6ba8cac3"), 7, new Guid("ae080daf-0a36-435a-995d-ea04bd417270"), "Tempo - 320" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("36e0e073-f0b3-4a73-95ed-1930247f5341"), 6, new Guid("ae080daf-0a36-435a-995d-ea04bd417270"), "Tempo - 600" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("84c9bc35-4986-4e8e-a360-e697254e7fbd"), 5, new Guid("ae080daf-0a36-435a-995d-ea04bd417270"), "Pause - 7 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3dca10d5-9eea-4ca6-9373-48b742156146"), 4, new Guid("ae080daf-0a36-435a-995d-ea04bd417270"), "Pause - 5 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0847de09-33a4-4644-b13e-9fd6828a336b"), 3, new Guid("ae080daf-0a36-435a-995d-ea04bd417270"), "Pause - 3 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("60f0810e-6f62-433b-bc2f-98dae4420386"), 2, new Guid("ae080daf-0a36-435a-995d-ea04bd417270"), "Pause - 2 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("084db1a2-1742-4368-8d04-527c20424f0c"), 8, new Guid("ae080daf-0a36-435a-995d-ea04bd417270"), "Tempo - 530" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a1f2ed13-2b11-4146-910c-ce009f3738fc"), 0, new Guid("327ae4f1-9ecd-49dc-a92e-bd71b4ac9694"), "Knee dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("855d5632-73f8-4482-afdb-e8a1f4183af2"), 3, new Guid("b645ef34-dc6f-4c6f-be58-6f65b13871f1"), "Low pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d653c304-ff57-4fde-897f-af97a2122b73"), 1, new Guid("b645ef34-dc6f-4c6f-be58-6f65b13871f1"), "Box" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bf107f88-a6f0-4174-9252-07a39bbd8e14"), 2, new Guid("327ae4f1-9ecd-49dc-a92e-bd71b4ac9694"), "Horizontal push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d0f646f0-ef8e-4867-8444-41d47b753260"), 3, new Guid("327ae4f1-9ecd-49dc-a92e-bd71b4ac9694"), "Horizontal pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("39986092-ce12-429b-a548-d48546c5870d"), 4, new Guid("327ae4f1-9ecd-49dc-a92e-bd71b4ac9694"), "Vertical push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("24ce0d25-f0bc-42f5-9f9f-b660ee6b6cf2"), 5, new Guid("327ae4f1-9ecd-49dc-a92e-bd71b4ac9694"), "Vertical pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f55e2dde-fcba-427d-86b9-12fa1447bad8"), 6, new Guid("327ae4f1-9ecd-49dc-a92e-bd71b4ac9694"), "Other" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("45aa65b3-90aa-4859-9a44-e9f1ba1d98af"), 0, new Guid("d4c3849f-d45c-4898-b660-c3598d3def6e"), "Barbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e25e0c06-2513-4a83-aa62-20935cc237f3"), 1, new Guid("d4c3849f-d45c-4898-b660-c3598d3def6e"), "Dumbbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("648db3a3-2c09-471f-86fa-2f574078717d"), 2, new Guid("d4c3849f-d45c-4898-b660-c3598d3def6e"), "Saftey bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f5756b70-5c0f-4685-ad06-82a4642d40a8"), 3, new Guid("d4c3849f-d45c-4898-b660-c3598d3def6e"), "Cambered bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e497586c-e713-4531-b682-eeb8e761bf59"), 4, new Guid("d4c3849f-d45c-4898-b660-c3598d3def6e"), "Neutral-grip bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1f8b6382-a05c-4305-876f-56356345925c"), 5, new Guid("d4c3849f-d45c-4898-b660-c3598d3def6e"), "Trap bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f9d66ac3-e9c0-4573-846f-a3890d69d3fb"), 6, new Guid("d4c3849f-d45c-4898-b660-c3598d3def6e"), "Buffalo bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f616456d-1103-4597-bd8a-c9fc7deec121"), 7, new Guid("d4c3849f-d45c-4898-b660-c3598d3def6e"), "Machine" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c1cb340e-940a-445b-91b5-db4945e97175"), 0, new Guid("c43f4f29-0a49-4855-80c8-ae096714da79"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3baf7cf0-19f5-4d9a-b381-fc762e0c519b"), 1, new Guid("c43f4f29-0a49-4855-80c8-ae096714da79"), "High bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c479d115-b203-4237-a65a-9834645f1611"), 2, new Guid("c43f4f29-0a49-4855-80c8-ae096714da79"), "Low bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("beebd9ee-6e89-4b35-82f5-3b5cdcd7edc7"), 3, new Guid("c43f4f29-0a49-4855-80c8-ae096714da79"), "Front rack" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("871ea182-d926-4fbc-886c-fa9c4c436185"), 0, new Guid("b645ef34-dc6f-4c6f-be58-6f65b13871f1"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8b2363fa-95cb-453a-a645-b5050a1e85f5"), 3, new Guid("4b229974-132b-45c1-9e04-b2ad3d20a31b"), "Wide grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("66a9d593-54f3-4b8e-85bb-9afdf7c89a42"), 2, new Guid("4b229974-132b-45c1-9e04-b2ad3d20a31b"), "Close grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8f44aef1-99a1-4a83-8075-04b7671f6ce7"), 1, new Guid("4b229974-132b-45c1-9e04-b2ad3d20a31b"), "Reverse grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4ebade0e-ad78-4d50-9998-9e7e60fcab15"), 0, new Guid("4b229974-132b-45c1-9e04-b2ad3d20a31b"), "Snatch grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e31361fa-f014-4c74-b53a-b88710735960"), 7, new Guid("13d5960c-2a43-447a-a628-760246cdf4fe"), "Wrist wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d14c2dcb-6149-4ac8-b748-b56d8b2ddfb9"), 2, new Guid("b645ef34-dc6f-4c6f-be58-6f65b13871f1"), "Towel" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("451343c3-8535-44d8-a182-ff60c62c4ca8"), 7, new Guid("13d5960c-2a43-447a-a628-760246cdf4fe"), "Deadlift suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7f65a899-9327-41db-a67f-6a2d4c69a04b"), 5, new Guid("13d5960c-2a43-447a-a628-760246cdf4fe"), "Squat suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("774ec694-6ce4-4046-8c30-aaa0eae7d078"), 4, new Guid("13d5960c-2a43-447a-a628-760246cdf4fe"), "Breifs" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("68c58ab4-5321-45d8-8d54-366463944040"), 3, new Guid("13d5960c-2a43-447a-a628-760246cdf4fe"), "Slingshot" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4f03f264-d3f7-44d1-ad73-04b2130732a2"), 2, new Guid("13d5960c-2a43-447a-a628-760246cdf4fe"), "Knee wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5b1a203b-532b-411c-bb1d-923b55031174"), 1, new Guid("13d5960c-2a43-447a-a628-760246cdf4fe"), "Knee sleeves" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5ada11a7-7360-49fd-a2fe-912e2299c7e5"), 0, new Guid("13d5960c-2a43-447a-a628-760246cdf4fe"), "Belt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7234a7fe-eed3-40bf-b17f-3174f5889e0b"), 6, new Guid("13d5960c-2a43-447a-a628-760246cdf4fe"), "Bench shirt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2a6900de-18c4-4b58-92d1-8b6225d48e31"), 0, new Guid("680c3314-0ac4-4275-8170-b4a1b73d0b86"), "Knee dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("685ca5ac-300b-40da-8099-0cb3adfc0546"), 6, new Guid("ba78b0b6-b632-403b-b96f-46bc5d025846"), "Reverse strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("54f02fc3-f5b2-419e-85a1-71459e98e7e0"), 5, new Guid("ba78b0b6-b632-403b-b96f-46bc5d025846"), "Reverse average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2e691345-8a4c-45b5-a9c0-cead4d1be9f3"), 4, new Guid("27606fc6-b45e-4c4d-a211-5b26eb59fee3"), "Middle pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4d90ecee-368e-4259-99a4-55e37f038ba1"), 5, new Guid("27606fc6-b45e-4c4d-a211-5b26eb59fee3"), "High pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2866383e-91c9-4514-a4aa-11fd97ea9fae"), 6, new Guid("27606fc6-b45e-4c4d-a211-5b26eb59fee3"), "Two inch deficit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0fb36bfc-27b4-479a-89d1-9ca0ffb8bc10"), 7, new Guid("27606fc6-b45e-4c4d-a211-5b26eb59fee3"), "Half board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("34febaa9-4c0c-4340-9760-c7baaa8e76d3"), 8, new Guid("27606fc6-b45e-4c4d-a211-5b26eb59fee3"), "Two board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9459ca3d-ef12-4457-a5b5-298c1a1fc6e3"), 9, new Guid("27606fc6-b45e-4c4d-a211-5b26eb59fee3"), "Three board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ea198c3e-caa4-4dce-8ac7-175fec4473cf"), 10, new Guid("27606fc6-b45e-4c4d-a211-5b26eb59fee3"), "Four board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("041e0c60-d3d2-4d8e-883a-3abf3e2ca56f"), 11, new Guid("27606fc6-b45e-4c4d-a211-5b26eb59fee3"), "Five board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("59a51223-965c-4f1f-8474-74529cbfc82d"), 12, new Guid("27606fc6-b45e-4c4d-a211-5b26eb59fee3"), "Towel - 8 cm " });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fc9ca369-df9c-49bc-9409-8fc7b5587397"), 0, new Guid("23c04279-a46d-4ac7-8bb0-40579e43b754"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a2678c33-c13a-450f-9160-59ac2aeabbc1"), 1, new Guid("23c04279-a46d-4ac7-8bb0-40579e43b754"), "Narrow" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d904bbf1-6227-464d-80ea-32efaac6531c"), 2, new Guid("23c04279-a46d-4ac7-8bb0-40579e43b754"), "Wide" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5fea5c90-4498-4ca4-a137-04c6b11874c6"), 3, new Guid("23c04279-a46d-4ac7-8bb0-40579e43b754"), "Sumo" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2f6cb7dc-1481-4c69-8859-8f1c9f767301"), 4, new Guid("23c04279-a46d-4ac7-8bb0-40579e43b754"), "Conventional" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1c59c9ef-6e71-402f-85c1-3141587a1afb"), 5, new Guid("23c04279-a46d-4ac7-8bb0-40579e43b754"), "Stiff legged" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b6eca23c-83c0-4ec5-9f69-4d71d295c366"), 6, new Guid("23c04279-a46d-4ac7-8bb0-40579e43b754"), "Feet up" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a33b884c-b01b-4551-9301-aa54b43d48d0"), 0, new Guid("8c96b12b-5fe3-4b15-a271-e26c51da3b02"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4eb345fd-3147-4a38-b4c6-658a01daa248"), 3, new Guid("b54fddef-a30d-4afd-b526-d47091aa69d7"), "Chains" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d66ee138-cc18-4b98-ba1d-776af31f4a7f"), 2, new Guid("b54fddef-a30d-4afd-b526-d47091aa69d7"), "Strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("54b327d0-e68d-43f5-b195-a0d214094803"), 1, new Guid("b54fddef-a30d-4afd-b526-d47091aa69d7"), "Average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("34690773-cadf-49ba-bfae-7361ced8e6fb"), 0, new Guid("b54fddef-a30d-4afd-b526-d47091aa69d7"), "Light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1fa090c9-f760-46e1-bf4b-c276e79bf36b"), 10, new Guid("8c96b12b-5fe3-4b15-a271-e26c51da3b02"), "Tempo - 003" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("746f9a5f-daca-431e-9ae6-ba7ea68845d1"), 9, new Guid("8c96b12b-5fe3-4b15-a271-e26c51da3b02"), "Tempo - 303" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6ce94428-6e69-4e1c-b83a-1ae1568bd274"), 3, new Guid("27606fc6-b45e-4c4d-a211-5b26eb59fee3"), "Low pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1a6f5ce7-7c2e-401b-8911-0294d14447c9"), 8, new Guid("8c96b12b-5fe3-4b15-a271-e26c51da3b02"), "Tempo - 530" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e0fe17a2-65e1-48cd-ae15-0cffc335c15f"), 6, new Guid("8c96b12b-5fe3-4b15-a271-e26c51da3b02"), "Tempo - 600" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1d4f801f-3ac0-4e80-9f4c-46379c011e9a"), 5, new Guid("8c96b12b-5fe3-4b15-a271-e26c51da3b02"), "Pause - 7 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2651239c-2b25-40f4-b139-65c282173730"), 4, new Guid("8c96b12b-5fe3-4b15-a271-e26c51da3b02"), "Pause - 5 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3113e94f-ee52-498c-ac67-d23d27c5b4d6"), 3, new Guid("8c96b12b-5fe3-4b15-a271-e26c51da3b02"), "Pause - 3 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a36eabdd-5c2e-4f77-b41a-82d75085ed0b"), 2, new Guid("8c96b12b-5fe3-4b15-a271-e26c51da3b02"), "Pause - 2 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("202dbcb6-e042-488f-bd47-e90ecf2aebe1"), 1, new Guid("8c96b12b-5fe3-4b15-a271-e26c51da3b02"), "Touch and go" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6f31b4d0-ada0-4b99-89de-cefc8f44efab"), 7, new Guid("8c96b12b-5fe3-4b15-a271-e26c51da3b02"), "Tempo - 320" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8d2d052c-16a1-431f-ae57-7d5e86c054a7"), 4, new Guid("b54fddef-a30d-4afd-b526-d47091aa69d7"), "Reverse light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("36740839-56d7-495e-af34-6e29021d9c56"), 2, new Guid("27606fc6-b45e-4c4d-a211-5b26eb59fee3"), "Towel" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9f3c96ca-e989-482c-aead-7809c27fe13c"), 0, new Guid("27606fc6-b45e-4c4d-a211-5b26eb59fee3"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("812be9b3-ba39-4f34-b8aa-046946229f70"), 1, new Guid("cf171282-137c-41f4-b732-1cc9e47886b7"), "Hip dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5c9a830e-f957-4097-bb69-9e80a36079a8"), 2, new Guid("cf171282-137c-41f4-b732-1cc9e47886b7"), "Horizontal push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("13c67799-3d6f-468d-b83e-4b1c1b93224c"), 3, new Guid("cf171282-137c-41f4-b732-1cc9e47886b7"), "Horizontal pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c4e1bf40-5ae0-478b-b14b-375e936e8c54"), 4, new Guid("cf171282-137c-41f4-b732-1cc9e47886b7"), "Vertical push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("01eaa38d-abb9-49ac-9ae2-903f30536971"), 5, new Guid("cf171282-137c-41f4-b732-1cc9e47886b7"), "Vertical pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9a79388b-485e-412c-9571-d873ac84a76c"), 6, new Guid("cf171282-137c-41f4-b732-1cc9e47886b7"), "Other" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4cb0acda-d622-48b7-a595-adfda0b96fe5"), 0, new Guid("1414296b-7d93-4f32-a161-65bfeb0b1028"), "Barbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("856907be-47e5-4ce6-987b-e4362118561b"), 1, new Guid("1414296b-7d93-4f32-a161-65bfeb0b1028"), "Dumbbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e7825a4a-ab92-4582-9add-b688c7e8010c"), 2, new Guid("1414296b-7d93-4f32-a161-65bfeb0b1028"), "Saftey bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d27dd49b-587c-4e45-a542-9daae9138495"), 3, new Guid("1414296b-7d93-4f32-a161-65bfeb0b1028"), "Cambered bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5cbe7c76-e173-4d5a-ae66-258650263216"), 4, new Guid("1414296b-7d93-4f32-a161-65bfeb0b1028"), "Neutral-grip bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("84754ee3-36e8-4cae-9722-9713c3ebc5eb"), 5, new Guid("1414296b-7d93-4f32-a161-65bfeb0b1028"), "Trap bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("11828ba3-4e84-45f4-ad3f-1c0a1ce3e510"), 6, new Guid("1414296b-7d93-4f32-a161-65bfeb0b1028"), "Buffalo bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4584783e-6bcd-4632-85a2-26fd4922446b"), 7, new Guid("1414296b-7d93-4f32-a161-65bfeb0b1028"), "Machine" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("df5b9be4-145e-472c-a979-622c70081145"), 0, new Guid("b3b93ea3-ecc5-49fb-a7cf-54ff1f32ea4f"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("df41a64f-3aa3-495e-8621-c88dd6c08df4"), 1, new Guid("b3b93ea3-ecc5-49fb-a7cf-54ff1f32ea4f"), "High bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bed1b3ed-8c1f-4fe6-ae3b-290b7ee4c964"), 2, new Guid("b3b93ea3-ecc5-49fb-a7cf-54ff1f32ea4f"), "Low bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f0f3a259-c3fd-439a-b925-5124a0c7f2bd"), 3, new Guid("8dac575b-0298-455c-a62d-5e04badebc57"), "Wide grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7e9804de-11a6-48cb-90e0-af73b5bb6f1d"), 2, new Guid("8dac575b-0298-455c-a62d-5e04badebc57"), "Close grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("277f579b-4238-403b-b23f-f5e319e65c5f"), 1, new Guid("8dac575b-0298-455c-a62d-5e04badebc57"), "Reverse grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c490c172-08aa-4c09-9af1-79c034a795ee"), 0, new Guid("8dac575b-0298-455c-a62d-5e04badebc57"), "Snatch grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5a8836cb-2d8e-411e-8067-7cd7d12fd456"), 7, new Guid("492edf8c-f9d9-460d-8dbe-5c7c5425bf98"), "Wrist wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("026e293b-1ad6-4669-aef2-4eb310baed96"), 7, new Guid("492edf8c-f9d9-460d-8dbe-5c7c5425bf98"), "Deadlift suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c8151319-a683-4ef5-b6d8-760a5abc7a51"), 1, new Guid("27606fc6-b45e-4c4d-a211-5b26eb59fee3"), "Box" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1688e621-a094-478f-99cd-b18270fd7428"), 6, new Guid("492edf8c-f9d9-460d-8dbe-5c7c5425bf98"), "Bench shirt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("94f9b0a7-9a23-4426-a74e-267e6704354f"), 4, new Guid("492edf8c-f9d9-460d-8dbe-5c7c5425bf98"), "Breifs" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2b5ac29d-e5e5-4086-9558-2a00cc383e80"), 3, new Guid("492edf8c-f9d9-460d-8dbe-5c7c5425bf98"), "Slingshot" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9dfcef3b-2d7e-4281-bfe4-a1ecff5e8e34"), 2, new Guid("492edf8c-f9d9-460d-8dbe-5c7c5425bf98"), "Knee wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ec00feff-48ba-41c6-a703-d6cf77fab4fd"), 1, new Guid("492edf8c-f9d9-460d-8dbe-5c7c5425bf98"), "Knee sleeves" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a0e9db37-e0d1-4517-8741-fcafddb6460e"), 0, new Guid("492edf8c-f9d9-460d-8dbe-5c7c5425bf98"), "Belt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("154f3f50-f620-410f-b465-8b3ad818d601"), 3, new Guid("b3b93ea3-ecc5-49fb-a7cf-54ff1f32ea4f"), "Front rack" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("381e1391-3537-42fc-aff4-80a5d08c8b0d"), 5, new Guid("492edf8c-f9d9-460d-8dbe-5c7c5425bf98"), "Squat suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("16d6e49c-684d-42f5-b7c6-84bce3fd57a3"), 5, new Guid("b54fddef-a30d-4afd-b526-d47091aa69d7"), "Reverse average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e03f4a3a-9ad6-4ec6-a4a5-e82f6ec4d6e5"), 6, new Guid("b54fddef-a30d-4afd-b526-d47091aa69d7"), "Reverse strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6c991be1-bf2f-43d8-baa8-7f912e170008"), 0, new Guid("a213c566-a91a-4cbf-8c01-871c27390d35"), "Knee dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("03f77a08-4896-4177-ab5a-e8a29bf720db"), 5, new Guid("2637c1da-cd98-4225-a084-0fdc7b3aba4e"), "High pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bb0c1513-429a-4ae5-9801-6af103e79f08"), 6, new Guid("2637c1da-cd98-4225-a084-0fdc7b3aba4e"), "Two inch deficit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bf41e6fa-422d-4e37-8056-41339bccd9ab"), 7, new Guid("2637c1da-cd98-4225-a084-0fdc7b3aba4e"), "Half board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e12df32d-2efd-442c-b869-32fc8f234589"), 8, new Guid("2637c1da-cd98-4225-a084-0fdc7b3aba4e"), "Two board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4c3dbe67-87ec-4edd-ad60-744fecfc738e"), 9, new Guid("2637c1da-cd98-4225-a084-0fdc7b3aba4e"), "Three board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("caaa4058-a4cf-412c-b39e-5eac76820711"), 10, new Guid("2637c1da-cd98-4225-a084-0fdc7b3aba4e"), "Four board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a74c8a27-7f4b-49b5-b030-f98fb4285c14"), 11, new Guid("2637c1da-cd98-4225-a084-0fdc7b3aba4e"), "Five board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e69b3aba-a769-46b4-9822-c84f12cf85a5"), 12, new Guid("2637c1da-cd98-4225-a084-0fdc7b3aba4e"), "Towel - 8 cm " });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5c6d3cbb-e468-4d87-a7b2-b3ae5cf9fbc7"), 0, new Guid("9fdb912b-fac9-49be-8f8b-17172e9a2c85"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bf0b0fa2-3222-4868-ba8e-01b02f8078d5"), 1, new Guid("9fdb912b-fac9-49be-8f8b-17172e9a2c85"), "Narrow" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2cd03023-be5d-4352-ab43-463a68195461"), 2, new Guid("9fdb912b-fac9-49be-8f8b-17172e9a2c85"), "Wide" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("31a33dcf-ec3a-413d-a512-fe7bcd2c931c"), 3, new Guid("9fdb912b-fac9-49be-8f8b-17172e9a2c85"), "Sumo" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e3cacad2-000f-465f-9fce-e7b98d7af0d1"), 4, new Guid("9fdb912b-fac9-49be-8f8b-17172e9a2c85"), "Conventional" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("716ccaec-7eb7-4f67-822e-d0a321704893"), 5, new Guid("9fdb912b-fac9-49be-8f8b-17172e9a2c85"), "Stiff legged" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3ac0c478-e595-43d0-8c9c-893a412b0ea6"), 6, new Guid("9fdb912b-fac9-49be-8f8b-17172e9a2c85"), "Feet up" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("13ce5ad0-ba50-431f-ac65-1649d7637ab5"), 0, new Guid("a5f0726a-1f75-4995-a2cb-dbfc4ceeee52"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7cc57d37-e3f8-4393-abee-8a8aad3f60f6"), 1, new Guid("a5f0726a-1f75-4995-a2cb-dbfc4ceeee52"), "Touch and go" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("001a60fc-2c7e-4e79-be11-2a366846c2f4"), 4, new Guid("ba78b0b6-b632-403b-b96f-46bc5d025846"), "Reverse light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d100dc61-620f-43a7-9b0d-d353e371a4b6"), 3, new Guid("ba78b0b6-b632-403b-b96f-46bc5d025846"), "Chains" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9b49b257-defe-4ae1-87a9-21407fce7b99"), 2, new Guid("ba78b0b6-b632-403b-b96f-46bc5d025846"), "Strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7dfc0a07-499a-4c38-9594-a911bb87cd3a"), 1, new Guid("ba78b0b6-b632-403b-b96f-46bc5d025846"), "Average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2cc399a4-f8cd-44da-95a6-3afa2b9afca9"), 0, new Guid("ba78b0b6-b632-403b-b96f-46bc5d025846"), "Light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7884c654-f095-4755-9a33-218cec411634"), 10, new Guid("a5f0726a-1f75-4995-a2cb-dbfc4ceeee52"), "Tempo - 003" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c5cf7aa1-1d77-468c-834f-cb24ca74841c"), 4, new Guid("2637c1da-cd98-4225-a084-0fdc7b3aba4e"), "Middle pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("af475942-8f5b-4cd3-b894-4a2d3cbb0189"), 9, new Guid("a5f0726a-1f75-4995-a2cb-dbfc4ceeee52"), "Tempo - 303" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c38e5b19-884b-4f7b-a1e0-ed84aea5e632"), 7, new Guid("a5f0726a-1f75-4995-a2cb-dbfc4ceeee52"), "Tempo - 320" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d7e24a68-caf9-4182-bef4-bb8c8c568c82"), 6, new Guid("a5f0726a-1f75-4995-a2cb-dbfc4ceeee52"), "Tempo - 600" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f2d834d9-e89a-4f0c-8abf-475f065e6579"), 5, new Guid("a5f0726a-1f75-4995-a2cb-dbfc4ceeee52"), "Pause - 7 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d48064d2-0bc8-4a04-af4c-213e6aa59198"), 4, new Guid("a5f0726a-1f75-4995-a2cb-dbfc4ceeee52"), "Pause - 5 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("13863b19-b072-44b6-b81c-11fb40f2f9dd"), 3, new Guid("a5f0726a-1f75-4995-a2cb-dbfc4ceeee52"), "Pause - 3 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a1007d6c-2490-4605-be35-1f9e5e03483f"), 2, new Guid("a5f0726a-1f75-4995-a2cb-dbfc4ceeee52"), "Pause - 2 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("74116904-b141-4bc3-ba4a-0c82bbafb638"), 8, new Guid("a5f0726a-1f75-4995-a2cb-dbfc4ceeee52"), "Tempo - 530" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("751c2ffc-5cef-417d-8bfc-7073b1f56374"), 3, new Guid("2637c1da-cd98-4225-a084-0fdc7b3aba4e"), "Low pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a84649c2-0089-4a14-a68e-ff4616a474e2"), 2, new Guid("2637c1da-cd98-4225-a084-0fdc7b3aba4e"), "Towel" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d0234c90-7b2d-4504-a382-08cdba21a3a0"), 1, new Guid("2637c1da-cd98-4225-a084-0fdc7b3aba4e"), "Box" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fe8094be-21c0-4cb2-bd4d-e07ff725249c"), 7, new Guid("fa93c83f-a4fc-4c13-81bf-117dd6a5de50"), "Machine" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5a509bc4-d937-41a1-80ca-0b1ac3815700"), 6, new Guid("fa93c83f-a4fc-4c13-81bf-117dd6a5de50"), "Buffalo bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9da70ee7-3094-48eb-84a3-f84cabd66c25"), 5, new Guid("fa93c83f-a4fc-4c13-81bf-117dd6a5de50"), "Trap bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ffae7dd5-ef75-4ef5-a6c5-81784f92cc2e"), 4, new Guid("fa93c83f-a4fc-4c13-81bf-117dd6a5de50"), "Neutral-grip bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c2925411-3c23-49f7-ad44-755746968342"), 3, new Guid("fa93c83f-a4fc-4c13-81bf-117dd6a5de50"), "Cambered bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("03ee3d7b-d48b-4407-9a60-5119628b429a"), 2, new Guid("fa93c83f-a4fc-4c13-81bf-117dd6a5de50"), "Saftey bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4544781b-2ed1-4183-b59e-db0348b7a419"), 0, new Guid("71a99dac-b986-4d92-84e1-715ae1c4aa54"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("324c0607-18b9-4ef7-888b-29836d397a99"), 1, new Guid("fa93c83f-a4fc-4c13-81bf-117dd6a5de50"), "Dumbbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("609436ef-887e-4c9c-bf23-1dd4f4317d65"), 6, new Guid("a213c566-a91a-4cbf-8c01-871c27390d35"), "Other" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e9e5a7c4-4bc7-49be-90c2-4f481aac7752"), 5, new Guid("a213c566-a91a-4cbf-8c01-871c27390d35"), "Vertical pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6361a19b-3a8f-4c15-978e-ead54d1bcc74"), 4, new Guid("a213c566-a91a-4cbf-8c01-871c27390d35"), "Vertical push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("724ee8e0-9542-461a-aa6d-c6e64e01b341"), 3, new Guid("a213c566-a91a-4cbf-8c01-871c27390d35"), "Horizontal pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("aad3c8f1-04c5-4013-9297-125444ca5b90"), 2, new Guid("a213c566-a91a-4cbf-8c01-871c27390d35"), "Horizontal push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("879df8eb-1f86-482a-afdd-6f69d245b483"), 1, new Guid("a213c566-a91a-4cbf-8c01-871c27390d35"), "Hip dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("eeea44e4-08d8-4332-bc97-3ec784ffc508"), 0, new Guid("fa93c83f-a4fc-4c13-81bf-117dd6a5de50"), "Barbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2cf24ff3-c105-47a0-8b6c-e29298593b0a"), 5, new Guid("5470d9fb-c969-45aa-81f2-5d4f9d63e609"), "Reverse average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("be57fbb0-6040-4fad-9e8a-d3bbd323b444"), 1, new Guid("71a99dac-b986-4d92-84e1-715ae1c4aa54"), "High bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8842fa97-1e8f-4360-a0bd-5e46ae166b82"), 3, new Guid("71a99dac-b986-4d92-84e1-715ae1c4aa54"), "Front rack" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("cec4d986-f729-49d3-a809-166fec84def3"), 0, new Guid("2637c1da-cd98-4225-a084-0fdc7b3aba4e"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b123d6f5-d4b4-4805-a6fb-db7cf909eaa0"), 3, new Guid("460af3c6-b087-4c43-b612-3b540573d95c"), "Wide grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("45c5de1d-a04e-4a1c-a2c2-9068c012020f"), 2, new Guid("460af3c6-b087-4c43-b612-3b540573d95c"), "Close grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d3eba990-fc0b-4ec6-a62c-48983921d15a"), 1, new Guid("460af3c6-b087-4c43-b612-3b540573d95c"), "Reverse grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f6cbc760-eae0-4d2f-93c8-3af35e19b804"), 0, new Guid("460af3c6-b087-4c43-b612-3b540573d95c"), "Snatch grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1e81b69a-3a03-4010-a107-48470d782349"), 7, new Guid("083fbf61-4b06-4e58-892f-48b325563e03"), "Wrist wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6ed056a8-c7a6-4c8d-93ea-91b5e910f0ac"), 2, new Guid("71a99dac-b986-4d92-84e1-715ae1c4aa54"), "Low bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3db67c58-1ab9-4b36-adb1-a932a9217db9"), 7, new Guid("083fbf61-4b06-4e58-892f-48b325563e03"), "Deadlift suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4af30448-1365-4e9f-b12a-bf6b1d0b2fa6"), 5, new Guid("083fbf61-4b06-4e58-892f-48b325563e03"), "Squat suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7dc9e6d8-848a-43ac-b679-365dbb299c6b"), 4, new Guid("083fbf61-4b06-4e58-892f-48b325563e03"), "Breifs" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d8d870a2-322f-4bfc-bb5a-bd3a342093a9"), 3, new Guid("083fbf61-4b06-4e58-892f-48b325563e03"), "Slingshot" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("58fd90ea-c134-4eec-b44b-e50989508d70"), 2, new Guid("083fbf61-4b06-4e58-892f-48b325563e03"), "Knee wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f0c344bf-4e30-4083-97a9-8a4c963cb530"), 1, new Guid("083fbf61-4b06-4e58-892f-48b325563e03"), "Knee sleeves" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0bfd7ea8-598f-42c6-ba49-648d3af2bafc"), 0, new Guid("083fbf61-4b06-4e58-892f-48b325563e03"), "Belt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f2dae296-c003-4862-85e1-6c5613ea670e"), 6, new Guid("083fbf61-4b06-4e58-892f-48b325563e03"), "Bench shirt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("13dfab50-e221-40c0-abfb-aaf1e19cb04f"), 6, new Guid("5470d9fb-c969-45aa-81f2-5d4f9d63e609"), "Reverse strong band" });

            migrationBuilder.InsertData(
                table: "ExerciseTypeTags",
                columns: new[] { "Id", "ExerciseTypeId", "Show", "TagId" },
                values: new object[,]
                {
                    { new Guid("1326ef2f-8770-437e-9216-fd7ea9244ea2"), new Guid("c0a0b90d-1ea8-47a5-9f90-6de9aafbf1d0"), true, new Guid("22f1365e-3b8e-4e85-bfaf-f7a3f337d209") },
                    { new Guid("3d06fee6-9940-4cc0-a39c-2316f1683a26"), new Guid("a267affa-2fc7-4085-a6aa-daa4f531ece0"), false, new Guid("f86f21d4-75ed-428e-a460-d8c23ad05e86") },
                    { new Guid("1a07c14f-835f-430d-a42b-3025d59f9e33"), new Guid("90f54812-230e-4fbd-bbdd-7b545456a768"), false, new Guid("daea1511-4213-4dfd-849d-d7fc846b5f0e") },
                    { new Guid("b0dce029-9b4e-439b-8a4f-3396557e8793"), new Guid("a267affa-2fc7-4085-a6aa-daa4f531ece0"), false, new Guid("7e3dcfd7-14bb-435a-bb0a-e32915ed24bd") },
                    { new Guid("371f4c8d-653c-42b7-a361-50e2350fdd1a"), new Guid("90f54812-230e-4fbd-bbdd-7b545456a768"), false, new Guid("9dbdd344-17b6-4a50-b224-724be130617d") },
                    { new Guid("45042074-e203-4de5-b8c1-c23cfb703c44"), new Guid("26ba685a-9543-4d14-a848-77dc5e741761"), false, new Guid("9dbdd344-17b6-4a50-b224-724be130617d") },
                    { new Guid("fbd037d8-a32e-4687-9b03-d935cffa7c32"), new Guid("a267affa-2fc7-4085-a6aa-daa4f531ece0"), false, new Guid("9dbdd344-17b6-4a50-b224-724be130617d") },
                    { new Guid("869337d6-79ad-4fb6-9b29-3dda98fd8cba"), new Guid("26ba685a-9543-4d14-a848-77dc5e741761"), true, new Guid("899e9e38-13c4-41cb-af9d-9dfc98b8e6e8") },
                    { new Guid("4978ff09-4ecc-4951-b2f6-cb7a6f2f4c6a"), new Guid("90f54812-230e-4fbd-bbdd-7b545456a768"), false, new Guid("f86f21d4-75ed-428e-a460-d8c23ad05e86") },
                    { new Guid("f2afb5a1-e3ed-48bc-bdd4-c1999c951e54"), new Guid("26ba685a-9543-4d14-a848-77dc5e741761"), true, new Guid("e7672caa-511d-49df-b856-1b9085126fd6") },
                    { new Guid("dbbe1803-e12d-4af7-bcf6-c1a7ce024bbb"), new Guid("90f54812-230e-4fbd-bbdd-7b545456a768"), true, new Guid("a73d798f-1d41-4bba-9e50-7efdb41970bf") },
                    { new Guid("754f60e0-c7b2-41d1-92bd-db63ed3f9f41"), new Guid("a267affa-2fc7-4085-a6aa-daa4f531ece0"), true, new Guid("a73d798f-1d41-4bba-9e50-7efdb41970bf") },
                    { new Guid("519ad5ef-652f-498b-91cf-db9a12697252"), new Guid("a267affa-2fc7-4085-a6aa-daa4f531ece0"), true, new Guid("74de7c7f-b9b3-4cac-beb0-4184deb56848") },
                    { new Guid("87e4fa1b-b4fc-497f-98b0-98073c27ec3e"), new Guid("90f54812-230e-4fbd-bbdd-7b545456a768"), true, new Guid("136de81c-3aa6-4d71-aa2a-16ecc2e0712a") },
                    { new Guid("fe91a6d9-a8cd-494e-b4bb-0f0c3ee1caf7"), new Guid("26ba685a-9543-4d14-a848-77dc5e741761"), true, new Guid("136de81c-3aa6-4d71-aa2a-16ecc2e0712a") },
                    { new Guid("4fa59c2f-5e62-4560-982d-d6160da7bffc"), new Guid("a267affa-2fc7-4085-a6aa-daa4f531ece0"), true, new Guid("136de81c-3aa6-4d71-aa2a-16ecc2e0712a") },
                    { new Guid("66f7f39f-0dc0-4a2d-b0d7-7c8ab7f0d1dd"), new Guid("26ba685a-9543-4d14-a848-77dc5e741761"), true, new Guid("18b49b52-c923-454d-bbc1-a128ee7ac366") },
                    { new Guid("c936cdfd-16e1-4fa6-b877-2fb91488fe1b"), new Guid("a267affa-2fc7-4085-a6aa-daa4f531ece0"), true, new Guid("51eea30e-56e0-45cb-a2f2-37511fc4bbf7") },
                    { new Guid("c98ef81b-2ae0-4cd1-bea6-b16641771da9"), new Guid("90f54812-230e-4fbd-bbdd-7b545456a768"), true, new Guid("9235ae68-04bf-487a-aff1-95f194145bb0") },
                    { new Guid("6dbaadd5-5483-4438-ae6b-96a136cc8ec8"), new Guid("26ba685a-9543-4d14-a848-77dc5e741761"), true, new Guid("92982ead-15d8-42b5-9a3d-87a1b9820c5a") },
                    { new Guid("3858d919-87cc-4be6-a555-9d94923fae40"), new Guid("4ceb30ac-cac8-48cb-9d36-ce87376e8fcb"), true, new Guid("86cc5bdf-179f-40ab-8d62-5d96bca006d6") },
                    { new Guid("9a58b221-fb06-4662-8f11-8808fe44e5a9"), new Guid("45e822b7-335c-4b5a-be13-5d5d2d84c8a2"), false, new Guid("64a4326a-5de2-4c3a-8e60-02a95a3c64f4") },
                    { new Guid("6f033179-9032-4d99-91a8-30fccb262823"), new Guid("4ceb30ac-cac8-48cb-9d36-ce87376e8fcb"), false, new Guid("1046e8bc-6241-438a-8b67-8983d471518b") },
                    { new Guid("9bf25426-3d28-4481-a9b9-871056470eb9"), new Guid("45e822b7-335c-4b5a-be13-5d5d2d84c8a2"), false, new Guid("1301b30f-4ae0-4574-ae5e-69a94a9b0de1") },
                    { new Guid("b13d2328-6b61-48ab-87af-7f5876bcd2b3"), new Guid("4ceb30ac-cac8-48cb-9d36-ce87376e8fcb"), false, new Guid("871ea182-d926-4fbc-886c-fa9c4c436185") },
                    { new Guid("8a8e9a6c-4382-4b25-b7ae-da63fd0492d7"), new Guid("638442e6-29b8-458f-a9a9-414186565efc"), false, new Guid("871ea182-d926-4fbc-886c-fa9c4c436185") },
                    { new Guid("c7d509f7-93a8-44ed-b12a-9fa2483f4122"), new Guid("45e822b7-335c-4b5a-be13-5d5d2d84c8a2"), false, new Guid("871ea182-d926-4fbc-886c-fa9c4c436185") },
                    { new Guid("1a236b1e-37fa-47ba-97fb-a81f89644fd9"), new Guid("638442e6-29b8-458f-a9a9-414186565efc"), true, new Guid("8b2363fa-95cb-453a-a645-b5050a1e85f5") },
                    { new Guid("70b17f9b-0500-42d4-accf-b4108c530efa"), new Guid("45e822b7-335c-4b5a-be13-5d5d2d84c8a2"), true, new Guid("a1f2ed13-2b11-4146-910c-ce009f3738fc") },
                    { new Guid("6fdf962f-5b8d-401c-981d-e3dbf7e93f62"), new Guid("638442e6-29b8-458f-a9a9-414186565efc"), true, new Guid("e31361fa-f014-4c74-b53a-b88710735960") },
                    { new Guid("46096fba-5300-4af6-b890-87f1a744a38f"), new Guid("4ceb30ac-cac8-48cb-9d36-ce87376e8fcb"), true, new Guid("5ada11a7-7360-49fd-a2fe-912e2299c7e5") },
                    { new Guid("c6eb48ae-6ea3-4b10-9f17-bffa758c6506"), new Guid("45e822b7-335c-4b5a-be13-5d5d2d84c8a2"), true, new Guid("5ada11a7-7360-49fd-a2fe-912e2299c7e5") },
                    { new Guid("33a4c87f-5ce3-4595-be49-9401e82fbeaa"), new Guid("45e822b7-335c-4b5a-be13-5d5d2d84c8a2"), true, new Guid("c479d115-b203-4237-a65a-9834645f1611") },
                    { new Guid("0c71916b-0c5d-4029-b36c-1ba2d297a718"), new Guid("4ceb30ac-cac8-48cb-9d36-ce87376e8fcb"), true, new Guid("45aa65b3-90aa-4859-9a44-e9f1ba1d98af") },
                    { new Guid("ad47d0e0-17eb-4583-9e21-0b1c9bc5c129"), new Guid("638442e6-29b8-458f-a9a9-414186565efc"), true, new Guid("45aa65b3-90aa-4859-9a44-e9f1ba1d98af") },
                    { new Guid("ce5b77f8-a558-4abd-a605-1bd5d6a5d334"), new Guid("45e822b7-335c-4b5a-be13-5d5d2d84c8a2"), true, new Guid("45aa65b3-90aa-4859-9a44-e9f1ba1d98af") },
                    { new Guid("a8a65c2d-b86b-4c7d-8cc3-c7e611d53f29"), new Guid("638442e6-29b8-458f-a9a9-414186565efc"), true, new Guid("bf107f88-a6f0-4174-9252-07a39bbd8e14") },
                    { new Guid("5bd57b6e-6a37-4d14-95fa-300d47270582"), new Guid("45e822b7-335c-4b5a-be13-5d5d2d84c8a2"), true, new Guid("5b1a203b-532b-411c-bb1d-923b55031174") },
                    { new Guid("dd652174-3a5f-4d1f-a5ee-0a858f493766"), new Guid("a267affa-2fc7-4085-a6aa-daa4f531ece0"), true, new Guid("2a6900de-18c4-4b58-92d1-8b6225d48e31") },
                    { new Guid("82a31169-9743-4df3-8815-e042b4573959"), new Guid("e5774f97-bacd-419a-852c-7f393f0984a9"), true, new Guid("13863b19-b072-44b6-b81c-11fb40f2f9dd") },
                    { new Guid("da8d4e95-4c4d-408e-8fef-9c5f30470dec"), new Guid("dc4de66d-1ebf-43df-8d51-e531699fdc63"), false, new Guid("13ce5ad0-ba50-431f-ac65-1649d7637ab5") },
                    { new Guid("1744f222-5e38-48a9-9325-d12cb265a58b"), new Guid("b294185e-360f-4169-b7f0-726a84401812"), false, new Guid("5fea5c90-4498-4ca4-a137-04c6b11874c6") },
                    { new Guid("39cf222b-c876-4667-89ff-fb90ce2ae282"), new Guid("c0a0b90d-1ea8-47a5-9f90-6de9aafbf1d0"), false, new Guid("fc9ca369-df9c-49bc-9409-8fc7b5587397") },
                    { new Guid("5efc3582-b3dd-4df2-9c9a-504f760f8fa2"), new Guid("b294185e-360f-4169-b7f0-726a84401812"), false, new Guid("9f3c96ca-e989-482c-aead-7809c27fe13c") },
                    { new Guid("8bf12041-02a9-4f55-b660-b2aae458dcf1"), new Guid("0d9483cb-bbde-44af-ad7f-ca94a99399f5"), false, new Guid("9f3c96ca-e989-482c-aead-7809c27fe13c") },
                    { new Guid("44300df8-f801-4aa9-95ae-452a0d1f702b"), new Guid("c0a0b90d-1ea8-47a5-9f90-6de9aafbf1d0"), false, new Guid("9f3c96ca-e989-482c-aead-7809c27fe13c") },
                    { new Guid("52d66d57-e413-42ca-9cfd-2adfda7c6f6a"), new Guid("0d9483cb-bbde-44af-ad7f-ca94a99399f5"), true, new Guid("f0f3a259-c3fd-439a-b925-5124a0c7f2bd") },
                    { new Guid("5bc2135d-6ff9-4d8a-b04c-d1a2b7c261c1"), new Guid("0d9483cb-bbde-44af-ad7f-ca94a99399f5"), true, new Guid("5a8836cb-2d8e-411e-8067-7cd7d12fd456") },
                    { new Guid("e4b76eb1-5e9e-4392-b9e7-8677769571cd"), new Guid("c0a0b90d-1ea8-47a5-9f90-6de9aafbf1d0"), false, new Guid("a33b884c-b01b-4551-9301-aa54b43d48d0") },
                    { new Guid("e5ca9b0e-7529-4de3-b00d-f3f78fc5f965"), new Guid("c0a0b90d-1ea8-47a5-9f90-6de9aafbf1d0"), true, new Guid("ec00feff-48ba-41c6-a703-d6cf77fab4fd") },
                    { new Guid("171e2c85-3ad2-4dfb-ac60-248df83a2ff1"), new Guid("c0a0b90d-1ea8-47a5-9f90-6de9aafbf1d0"), true, new Guid("a0e9db37-e0d1-4517-8741-fcafddb6460e") },
                    { new Guid("b784c244-64d1-4163-b51d-f284da419c04"), new Guid("c0a0b90d-1ea8-47a5-9f90-6de9aafbf1d0"), true, new Guid("bed1b3ed-8c1f-4fe6-ae3b-290b7ee4c964") },
                    { new Guid("cefe2c33-0ffb-4298-b1b6-918d6c0bddc6"), new Guid("b294185e-360f-4169-b7f0-726a84401812"), true, new Guid("4cb0acda-d622-48b7-a595-adfda0b96fe5") },
                    { new Guid("6662d01f-ef27-4344-a40e-c27be8a71356"), new Guid("0d9483cb-bbde-44af-ad7f-ca94a99399f5"), true, new Guid("4cb0acda-d622-48b7-a595-adfda0b96fe5") },
                    { new Guid("9b38d7fb-69ec-4541-b71a-e77ac4ab9659"), new Guid("c0a0b90d-1ea8-47a5-9f90-6de9aafbf1d0"), true, new Guid("4cb0acda-d622-48b7-a595-adfda0b96fe5") },
                    { new Guid("861fbf4c-7ea1-443c-b0e0-4f42c73c9bbb"), new Guid("0d9483cb-bbde-44af-ad7f-ca94a99399f5"), true, new Guid("5c9a830e-f957-4097-bb69-9e80a36079a8") },
                    { new Guid("0039c7d2-5318-4013-adb6-1131e834811a"), new Guid("b294185e-360f-4169-b7f0-726a84401812"), true, new Guid("812be9b3-ba39-4f34-b8aa-046946229f70") },
                    { new Guid("defc4d0d-5bc5-48c1-8d9d-f3ea0b67712c"), new Guid("b294185e-360f-4169-b7f0-726a84401812"), true, new Guid("a0e9db37-e0d1-4517-8741-fcafddb6460e") },
                    { new Guid("b321bc88-6621-42de-8f10-bfb0d629fe7d"), new Guid("b294185e-360f-4169-b7f0-726a84401812"), false, new Guid("a33b884c-b01b-4551-9301-aa54b43d48d0") },
                    { new Guid("4814b90d-94cf-4352-9b1c-6a43c748189f"), new Guid("0d9483cb-bbde-44af-ad7f-ca94a99399f5"), true, new Guid("3113e94f-ee52-498c-ac67-d23d27c5b4d6") },
                    { new Guid("6ec90a7c-94a5-4b3b-b1a6-fc9fcfa05c72"), new Guid("2ade937e-231c-4fc6-b48b-31bf7773e8a3"), true, new Guid("6c991be1-bf2f-43d8-baa8-7f912e170008") },
                    { new Guid("26129fce-56a5-4bc5-97f2-7839613d86e1"), new Guid("2ade937e-231c-4fc6-b48b-31bf7773e8a3"), false, new Guid("13ce5ad0-ba50-431f-ac65-1649d7637ab5") },
                    { new Guid("363c26a8-7c85-4062-8406-51fccf827c7d"), new Guid("dc4de66d-1ebf-43df-8d51-e531699fdc63"), false, new Guid("31a33dcf-ec3a-413d-a512-fe7bcd2c931c") },
                    { new Guid("06ba0d49-31e4-4579-82cb-fe19325d7728"), new Guid("2ade937e-231c-4fc6-b48b-31bf7773e8a3"), false, new Guid("5c6d3cbb-e468-4d87-a7b2-b3ae5cf9fbc7") },
                    { new Guid("c93153a6-005a-4baa-a0d5-eda1126487d1"), new Guid("dc4de66d-1ebf-43df-8d51-e531699fdc63"), false, new Guid("cec4d986-f729-49d3-a809-166fec84def3") },
                    { new Guid("e11f1eef-d66b-463a-a0f8-52de5b9e5a1c"), new Guid("e5774f97-bacd-419a-852c-7f393f0984a9"), false, new Guid("cec4d986-f729-49d3-a809-166fec84def3") },
                    { new Guid("de49183f-4347-49a2-9511-51927bef1fef"), new Guid("2ade937e-231c-4fc6-b48b-31bf7773e8a3"), false, new Guid("cec4d986-f729-49d3-a809-166fec84def3") },
                    { new Guid("c5b3da9d-7230-438b-b973-f6ae3493b194"), new Guid("e5774f97-bacd-419a-852c-7f393f0984a9"), true, new Guid("b123d6f5-d4b4-4805-a6fb-db7cf909eaa0") },
                    { new Guid("eab45774-3831-4760-8edc-5e414589d611"), new Guid("e5774f97-bacd-419a-852c-7f393f0984a9"), true, new Guid("1e81b69a-3a03-4010-a107-48470d782349") },
                    { new Guid("f45141f0-cac0-4660-80fc-848eeb593d5e"), new Guid("2ade937e-231c-4fc6-b48b-31bf7773e8a3"), true, new Guid("f0c344bf-4e30-4083-97a9-8a4c963cb530") },
                    { new Guid("2177e925-ba93-4af0-9238-b01a32267e68"), new Guid("dc4de66d-1ebf-43df-8d51-e531699fdc63"), true, new Guid("0bfd7ea8-598f-42c6-ba49-648d3af2bafc") },
                    { new Guid("a42e99ff-3074-4996-8cb2-47d902ad54da"), new Guid("2ade937e-231c-4fc6-b48b-31bf7773e8a3"), true, new Guid("0bfd7ea8-598f-42c6-ba49-648d3af2bafc") },
                    { new Guid("6c591faa-b3ea-4925-a6b9-a8268c0d972a"), new Guid("2ade937e-231c-4fc6-b48b-31bf7773e8a3"), true, new Guid("6ed056a8-c7a6-4c8d-93ea-91b5e910f0ac") },
                    { new Guid("f32234c7-2a80-4083-b764-83d3108364e9"), new Guid("dc4de66d-1ebf-43df-8d51-e531699fdc63"), true, new Guid("eeea44e4-08d8-4332-bc97-3ec784ffc508") },
                    { new Guid("b71545ea-e4df-4df8-9d9e-c71624899a45"), new Guid("e5774f97-bacd-419a-852c-7f393f0984a9"), true, new Guid("eeea44e4-08d8-4332-bc97-3ec784ffc508") },
                    { new Guid("b18b3207-ace1-4efb-ac25-c42d12cdc588"), new Guid("2ade937e-231c-4fc6-b48b-31bf7773e8a3"), true, new Guid("eeea44e4-08d8-4332-bc97-3ec784ffc508") },
                    { new Guid("a0583345-ec50-4265-8c3c-61b19e1fd73f"), new Guid("e5774f97-bacd-419a-852c-7f393f0984a9"), true, new Guid("aad3c8f1-04c5-4013-9297-125444ca5b90") },
                    { new Guid("49536ae6-eca0-4620-842b-974e0cad0eb9"), new Guid("dc4de66d-1ebf-43df-8d51-e531699fdc63"), true, new Guid("879df8eb-1f86-482a-afdd-6f69d245b483") },
                    { new Guid("9ec77833-7b5d-4b4c-a649-a765fa5d1a47"), new Guid("4ceb30ac-cac8-48cb-9d36-ce87376e8fcb"), false, new Guid("64a4326a-5de2-4c3a-8e60-02a95a3c64f4") },
                    { new Guid("22dfe93e-6927-487e-8224-e4ae6b515034"), new Guid("638442e6-29b8-458f-a9a9-414186565efc"), true, new Guid("0847de09-33a4-4644-b13e-9fd6828a336b") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_ExerciseTypes_ExerciseTypeId",
                table: "Exercises",
                column: "ExerciseTypeId",
                principalTable: "ExerciseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Trainings_TrainingId",
                table: "Exercises",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id");
        }
    }
}
