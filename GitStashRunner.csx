#load "CommandRunner.csx"

public class GitStashRunner {
 public static void StashChanges() {
  CommandRunner.Execute("git stash -q --keep-index");
 }public static void UnstashChanges() {
  CommandRunner.Execute("git stash pop -q");
 }
}